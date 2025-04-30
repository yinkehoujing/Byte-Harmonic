using System;
using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography;
using System.Text;
using Konscious.Security.Cryptography;

namespace Byte_Harmonic.Utils;

/// <summary>
/// 使用 Argon2id 算法实现的密码哈希器（基于 Konscious.Security.Cryptography 库）
/// </summary>
public static class PasswordHasher
{
    // 常量参数，可根据服务器资源调整
    private const int SaltSize = 16; // 盐值大小（16 字节 = 128 位）
    private const int DegreeOfParallelism = 4; // 并行线程数（通常为 CPU 核心数）
    private const int MemorySize = 1024 * 64; // 内存大小，单位 KB（64MB）
    private const int Iterations = 4; // 迭代次数
    private const int HashLength = 32; // 哈希输出长度（32 字节 = 256 位）

    /// <summary>
    /// 生成密码哈希值，返回格式："argon2id:Iterations:DegreeOfParallelism:MemorySize:Base64Salt:Base64Hash"
    /// </summary>
    public static string Hash(string password)
    {
        // 生成加盐
        var salt = new byte[SaltSize];
        RandomNumberGenerator.Fill(salt);

        // 创建 Argon2id 实例并配置参数
        var argon2 = new Argon2id(Encoding.UTF8.GetBytes(password))
        {
            Salt = salt,
            DegreeOfParallelism = DegreeOfParallelism,
            MemorySize = MemorySize, // 单位 KB
            Iterations = Iterations
        };

        // 计算哈希
        var hash = argon2.GetBytes(HashLength);

        // 格式化输出
        return $"argon2id:{Iterations}:{DegreeOfParallelism}:{MemorySize}:{Convert.ToBase64String(salt)}:{Convert.ToBase64String(hash)}";
    }

    /// <summary>
    /// 验证密码是否与原哈希匹配
    /// </summary>
    public static bool Verify(string password, string hashedPassword)
    {
        // 解析哈希格式
        if (!TryParseHash(hashedPassword, out var parameters, out var salt, out var storedHash))
        {
            throw new FormatException("哈希格式无效");
        }

        // 创建 Argon2id 实例并配置解析出来的参数
        var argon2 = new Argon2id(Encoding.UTF8.GetBytes(password))
        {
            Salt = salt,
            DegreeOfParallelism = parameters.Value.DegreeOfParallelism,
            MemorySize = parameters.Value.MemorySize,
            Iterations = parameters.Value.Iterations
        };

        // 计算新的哈希
        var computedHash = argon2.GetBytes(storedHash.Length);

        // 使用常数时间比较，防止时序攻击
        return CryptographicOperations.FixedTimeEquals(computedHash, storedHash);
    }

    /// <summary>
    /// 尝试从哈希字符串中提取参数、盐值和哈希内容
    /// </summary>
    private static bool TryParseHash(
        string hashedPassword,
        [NotNullWhen(true)] out (int Iterations, int DegreeOfParallelism, int MemorySize)? parameters,
        [NotNullWhen(true)] out byte[]? salt,
        [NotNullWhen(true)] out byte[]? hash)
    {
        var parts = hashedPassword.Split(':');
        if (parts.Length != 6 || parts[0] != "argon2id")
        {
            parameters = null;
            salt = null;
            hash = null;
            return false;
        }

        try
        {
            parameters = (
                Iterations: int.Parse(parts[1]),
                DegreeOfParallelism: int.Parse(parts[2]),
                MemorySize: int.Parse(parts[3])
            );
            salt = Convert.FromBase64String(parts[4]);
            hash = Convert.FromBase64String(parts[5]);
            return true;
        }
        catch
        {
            parameters = null;
            salt = null;
            hash = null;
            return false;
        }
    }
}
