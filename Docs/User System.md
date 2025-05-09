# User  System

## 功能概览

- **用户注册**：新用户可以通过提供账号、密码和可选用户名进行注册
- **用户登录/登出**：用户使用账号密码登录系统，支持登出功能
- **密码管理**：支持修改密码，需验证当前密码
- **用户信息更新**：可以更新用户名等基本信息
- **账户删除**：用户可以删除自己的账户，需密码确认
- **权限管理**：区分普通用户和管理员用户
- **收藏功能**：用户可以收藏/取消收藏歌曲，查看收藏列表
- **搜索历史**：记录用户搜索历史，支持查看和清空历史

## 业务逻辑简介

### 用户认证流程

1. **初始化**：创建`UserService`实例，注入`UserRepository`
   ```csharp
   private readonly UserRepository _userRepository;
   public User? _currentUser;
   
   public UserService(UserRepository userRepository)
   {
       _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
   }
   ```

2. **用户登录**：验证账号密码，设置当前用户
   ```csharp
   var user = await _userRepository.GetUserByAccountAsync(account);
   if (user == null || !await _userRepository.VerifyPasswordAsync(account, password))
       throw new UnauthorizedAccessException("账号或密码错误");
   
   _currentUser = user;
   ```

3. **用户登出**：清空当前用户
   ```csharp
   public void Logout()
   {
       _currentUser = null;
   }
   ```

### 用户注册流程

1. 验证输入有效性
2. 检查账号是否已存在
3. 创建新用户并保存到数据库
   ```csharp
   var user = new User
   {
       Account = account.Trim(),
       Username = string.IsNullOrWhiteSpace(username) ? account.Trim() : username.Trim(),
       Password = password,
       IsAdmin = isAdmin
   };
   
   var success = await _userRepository.AddUserAsync(user);
   ```

### 收藏功能

1. **添加收藏**：检查是否已收藏，然后添加记录
   ```csharp
   if (IsSongFavorite(username, songId)) return false;
   
   const string sql = "INSERT INTO Favorites (Username, SongId) VALUES (@Username, @SongId)";
   ```

2. **移除收藏**：删除收藏记录
   ```csharp
   const string sql = "DELETE FROM Favorites WHERE Username = @Username AND SongId = @SongId";
   ```

3. **获取收藏列表**：查询用户收藏的所有歌曲
   ```csharp
   const string sql = @"SELECT s.Id, s.Title, s.Artist, s.MusicFilePath, s.LrcFilePath, s.Downloaded, s.Duration
                       FROM Favorites f
                       JOIN Songs s ON f.SongId = s.Id
                       WHERE f.Username = @Username";
   ```

### 搜索历史

1. **添加记录**：检查是否已存在相同记录，更新或插入
   ```csharp
   var exists = (long)await checkCmd.ExecuteScalarAsync() > 0;
   if (exists) {
       // 更新时间
   } else {
       // 插入新记录
   }
   ```

2. **获取历史**：按时间倒序返回最近的搜索记录
   ```csharp
   const string sql = @"SELECT Keyword FROM SearchHistory 
                       WHERE Username = @Username 
                       ORDER BY Time DESC 
                       LIMIT @Limit";
   ```

## 相关实体类

### `User` 类
```csharp
public class User
{
    public string Account { get; set; }    // 用户账号
    public string Username { get; set; }   // 显示名称
    public string Password { get; set; }   // 哈希后的密码
    public bool IsAdmin { get; set; }      // 是否为管理员
}
```

## 数据访问层接口

### `UserRepository` 方法列表

#### 用户管理
- `Task<bool> AddUserAsync(User user)` - 添加新用户
- `Task<User?> GetUserByAccountAsync(string account)` - 根据账号获取用户
- `Task<bool> VerifyPasswordAsync(string account, string inputPassword)` - 验证密码
- `Task<bool> UpdateUserInfoAsync(User user)` - 更新用户信息
- `Task<bool> UpdatePasswordAsync(string account, string newPassword)` - 更新密码
- `Task<bool> DeleteUserAsync(string account)` - 删除用户

#### 收藏功能
- `bool IsSongFavorite(string username, int songId)` - 检查是否已收藏
- `Task<bool> AddFavoriteSongAsync(string username, int songId)` - 添加收藏
- `Task<bool> RemoveFavoriteSongAsync(string username, int songId)` - 移除收藏
- `Task<List<Song>> GetFavoriteSongsAsync(string username)` - 获取收藏列表
- `Task<int> GetFavoriteSongsCountAsync(string username)` - 获取收藏数量
- `Task<bool> AddFavoriteSongsAsync(string username, IEnumerable<int> songIds)` - 批量添加收藏
- `Task<bool> ClearAllFavoritesAsync(string username)` - 清空收藏

#### 搜索历史
- `Task<bool> AddSearchHistoryAsync(string username, string keyword)` - 添加搜索记录
- `Task<List<string>> GetSearchHistoryAsync(string username, int limit = 10)` - 获取搜索历史
- `Task<bool> ClearSearchHistoryAsync(string username)` - 清空搜索历史
- `Task<bool> UpdateSearchHistoryAsync(string username, List<string> history)` - 更新搜索历史

## 相关数据库表

### `Users` 表结构

| 字段名       | 类型    | 约束       | 描述                     |
|-------------|---------|------------|--------------------------|
| `Account`   | VARCHAR | PRIMARY KEY| 用户账号，唯一标识       |
| `Username`  | VARCHAR | NOT NULL   | 用户显示名称             |
| `Password`  | VARCHAR | NOT NULL   | 哈希后的密码             |
| `IsAdmin`   | BOOLEAN | DEFAULT 0  | 是否为管理员             |

### `Favorites` 表结构

| 字段名       | 类型    | 约束                     | 描述                     |
|-------------|---------|--------------------------|--------------------------|
| `Username`  | VARCHAR | FOREIGN KEY, NOT NULL    | 关联用户账号             |
| `SongId`    | INTEGER | FOREIGN KEY, NOT NULL    | 关联歌曲ID               |
| 复合主键: (Username, SongId) |         |                          |                          |

### `SearchHistory` 表结构

| 字段名       | 类型      | 约束                     | 描述                     |
|-------------|-----------|--------------------------|--------------------------|
| `Username`  | VARCHAR   | FOREIGN KEY, NOT NULL    | 关联用户账号             |
| `Keyword`   | VARCHAR   | NOT NULL                 | 搜索关键词               |
| `Time`      | TIMESTAMP | NOT NULL                 | 搜索时间                 |

## 说明

1. 所有密码都经过哈希处理存储，确保安全性
2. 用户账号作为主键，确保唯一性
3. 收藏关系通过复合主键确保唯一性
4. 搜索历史按时间排序，方便获取最近记录
5. 管理员权限通过`IsAdmin`字段控制