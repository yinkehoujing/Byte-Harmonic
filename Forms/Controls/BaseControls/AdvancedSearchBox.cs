﻿/*using Byte_Harmonic.Forms.FormUtils;
using Sunny.UI;
using System.Windows.Forms;
public class UIDropDownPanel : UIPanel
{
    public UIDropDownPanel()
    {
        this.Visible = false;
        this.BackColor = Color.White;
        this.Style = UIStyle.Custom;
        this.RectColor = MPColor.Grey1;
        this.FillColor = MPColor.Grey1;
    }

    public void Show(Control control, Point location)
    {
        if (control.Parent == null) return;

        this.Location = control.Parent.PointToClient(
            control.PointToScreen(location));
        this.Parent = control.Parent;
        this.BringToFront();
        this.Visible = true;
    }

    public new void Hide()
    {
        this.Visible = false;
    }
}

public class AdvancedSearchBox : UITextBox
{
    private UIDropDownPanel _dropDownPanel;
    private ListBox _suggestionList;
    private FlowLayoutPanel _historyPanel;
    private Label _separator;
    private UILabel _historyLabel;
    private Panel suggestionPanel;
    public int BoxWidth = 300;
    public int MaxHeight = 300;

    // 事件定义
    public event Action<string> SearchTriggered;
    public event Func<string, Task<List<string>>> GetSuggestions;
    public event Func<Task<List<string>>> GetHistoryTags;
    public event Action<List<string>> HistoryChanged;

    public AdvancedSearchBox()
    {
        InitializeComponents();
        SetupEvents();
    }

    private void InitializeComponents()
    {
        this.rectColor = MPColor.Grey3;
        this.Font = new Font("黑体", 15);
        
        // 初始化下拉面板
        _dropDownPanel = new UIDropDownPanel();
        _dropDownPanel.Width = BoxWidth;
        _dropDownPanel.MaximumSize = new Size(BoxWidth, 400);
        _dropDownPanel.AutoScroll = false;
        _dropDownPanel.Padding = new Padding(5);
        _dropDownPanel.RectColor = MPColor.Grey3;

        // 初始化建议列表
        suggestionPanel = new Panel();
        suggestionPanel.MaximumSize = new Size(BoxWidth, 370);
        suggestionPanel.Dock = DockStyle.Top;
        suggestionPanel.AutoScroll = true;
        suggestionPanel.Font = new Font("黑体", 15);
        suggestionPanel.Padding = new Padding(5);
        
        _suggestionList = new ListBox();
        _suggestionList.Dock = DockStyle.Fill;
        _suggestionList.BorderStyle = BorderStyle.None;
        _suggestionList.Cursor = Cursors.Hand;
        _suggestionList.BackColor = MPColor.Grey1;
        suggestionPanel.Controls.Add(_suggestionList); 
        

        // 初始化分隔线
        _separator = new Label();
        _separator.Dock = DockStyle.Top;
        _separator.Height = 1;
        _separator.BackColor = Color.White;
        _separator.Text = "";
        _separator.Visible = false;

        // 初始化历史记录标题 
        _historyLabel = new UILabel();
        _historyLabel.Dock = DockStyle.Top;
        _historyLabel.Text = "历史记录";
        _historyLabel.Font = new Font("黑体", 12, FontStyle.Bold);
        _historyLabel.Margin = new Padding(5);
        _historyLabel.Visible = false;
        _historyLabel.Height = 15;

        // 历史记录面板
        _historyPanel = new FlowLayoutPanel();
        _historyPanel.Dock = DockStyle.Top;
        _historyPanel.Size = new Size(BoxWidth,35);
        _historyPanel.AutoScroll = true;
        _historyPanel.Padding = new Padding(5);
        _historyPanel.WrapContents = true;
        _historyPanel.BackColor = Color.White;
        _historyPanel.Padding = new Padding(5);
        _historyPanel.BackColor = MPColor.Grey1;

        // 组装下拉面板
        _dropDownPanel.Controls.Add(_historyPanel);
        _dropDownPanel.Controls.Add(_historyLabel);
        _dropDownPanel.Controls.Add(_separator);
        _dropDownPanel.Controls.Add(suggestionPanel);

        // 添加底部填充面板确保布局正确
        Panel fillPanel = new Panel();
        fillPanel.Dock = DockStyle.Fill;
        _dropDownPanel.Controls.Add(fillPanel);
    }

    private void SetupEvents()
    {
        this.TextChanged += (s, e) => UpdateSuggestions();//搜索框文字改变

        this.KeyDown += (s, e) =>   //键盘操作
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchTriggered?.Invoke(this.Text);
                HideDropDown();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                HideDropDown();
            }
        };

        _suggestionList.MouseClick += (s, e) => //鼠标点击
        {
            if (_suggestionList.SelectedItem != null)
            {
                this.Text = _suggestionList.SelectedItem.ToString();
                SearchTriggered?.Invoke(this.Text);
                HideDropDown();
            }
        };
    }

    private void UpdateSuggestions()
    {
        if (string.IsNullOrWhiteSpace(this.Text))
        {
            HideDropDown();
            return;
        }

        // 获取建议项
        var suggestions = GetSuggestions?.Invoke(this.Text) ?? new List<string>();
        bool hasSuggestions = suggestions.Count > 0;
        _suggestionList.Items.Clear();
        _suggestionList.Items.AddRange(suggestions.ToArray());
        _suggestionList.ItemHeight = 20;
        suggestionPanel.Height = suggestions.Count * 20;// 高度
        _suggestionList.Height = suggestions.Count * 20;// 高度

        // 获取历史记录
        var historyTags = GetHistoryTags?.Invoke() ?? new List<string>();
        _historyPanel.Controls.Clear();

        // 设置历史记录区域可见性
        bool hasHistory = historyTags.Count > 0;
        _historyLabel.Visible = hasHistory;
        _historyPanel.Visible = hasHistory;

        // 添加历史记录标签
        foreach (var tag in historyTags)
        {
            // 创建容器面板，用于放置标签和删除按钮
            var containerPanel = new Panel();
            containerPanel.AutoSize = false;
            containerPanel.Height = 20;
            containerPanel.Margin = new Padding(2,5,2,5);

            // 创建标签按钮
            var tagLabel = new UIButton();
            tagLabel.Text = tag;
            tagLabel.Style = UIStyle.Custom;
            tagLabel.Dock = DockStyle.Left;
            tagLabel.Font = new Font("黑体", 10);

            // 计算文本所需宽度
            using (Graphics g = tagLabel.CreateGraphics())
            {
                SizeF size = g.MeasureString(tag, tagLabel.Font);
                tagLabel.Width = (int)size.Width + 5; // 增加一些内边距
            }

            tagLabel.FillColor = Color.FromArgb(240, 240, 240);
            tagLabel.RectColor = Color.FromArgb(200, 200, 200);
            tagLabel.ForeColor = Color.Black;
            tagLabel.Cursor = Cursors.Hand;
            tagLabel.Click += (s, e) =>
            {
                this.Text = tag;
                SearchTriggered?.Invoke(tag);
                HideDropDown();
            };

            // 创建删除按钮
            var deleteButton = new UIButton();
            deleteButton.Text = "✕";
            deleteButton.Style = UIStyle.Custom;
            deleteButton.Dock = DockStyle.Right;
            deleteButton.Width = 13;
            deleteButton.FillColor = Color.FromArgb(240, 240, 240);
            deleteButton.RectColor = Color.FromArgb(200, 200, 200);
            deleteButton.ForeColor = Color.Black;
            deleteButton.Font = new Font(tagLabel.Font.FontFamily, 9, FontStyle.Bold);
            deleteButton.Cursor = Cursors.Hand;
            deleteButton.Click += (s, e) =>
            {

                // 从历史记录中移除该项
                var currentHistory = GetHistoryTags?.Invoke() ?? new List<string>();
                currentHistory.Remove(tag);

                // 触发历史记录更新事件（需要你在类中定义这个事件）
                HistoryChanged?.Invoke(currentHistory);

                // 刷新下拉面板
                UpdateSuggestions();
            };

            // 将控件添加到容器
            containerPanel.Controls.Add(deleteButton);
            containerPanel.Controls.Add(tagLabel);

            // 设置容器总宽度
            containerPanel.Width = tagLabel.Width + deleteButton.Width;

            // 将容器添加到历史记录面板
            _historyPanel.Controls.Add(containerPanel);
        }

        // 计算并设置下拉面板高度
        int suggestionHeight = hasSuggestions ? suggestionPanel.Height : 0;
        int historyHeight = hasHistory ? 30 : 0;
        int headerHeight = hasHistory ? 15 : 0;
        int separatorHeight = 0;

        _separator.Height = headerHeight;
        _historyLabel.Height = headerHeight;
        _dropDownPanel.Height = suggestionHeight  +separatorHeight+headerHeight + historyHeight + 30; //10为额外边距

        // 显示下拉面板
        if (suggestions.Count > 0 || historyTags.Count > 0)
        {
            ShowDropDown();
        }
        else
        {
            HideDropDown();
        }
    }

    private void ShowDropDown()
    {
        if (!_dropDownPanel.Visible)
        {
            _dropDownPanel.Show(this, new Point(0, this.Height));
        }
    }

    private void HideDropDown()
    {
        _dropDownPanel.Hide();
    }
}*/
using Byte_Harmonic.Forms.FormUtils;
using Sunny.UI;
using System.Windows.Forms;
using System.Drawing;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Byte_Harmonic.Forms;

public class UIDropDownPanel : UIPanel
{
    public UIDropDownPanel()
    {
        this.Visible = false;
        this.BackColor = Color.White;
        this.Style = UIStyle.Custom;
        this.RectColor = MPColor.Grey1;
        this.FillColor = MPColor.Grey1;
    }

    public void Show(Control control, Point location)
    {
        if (control.Parent == null) return;

        this.Location = control.Parent.PointToClient(
            control.PointToScreen(location));
        this.Parent = control.Parent;
        this.BringToFront();
        this.Visible = true;
    }

    public new void Hide()
    {
        this.Visible = false;
    }
}

public class AdvancedSearchBox : UITextBox
{
    private UIDropDownPanel _dropDownPanel;
    private ListBox _suggestionList;
    private FlowLayoutPanel _historyPanel;
    private Label _separator;
    private UILabel _historyLabel;
    private Panel suggestionPanel;
    public int BoxWidth = 300;
    public int MaxHeight = 300;

    // 修改为异步事件
    public event Action<string> SearchTriggered;
    public event Func<string, Task<List<string>>> GetSuggestions;
    public event Func<Task<List<string>>> GetHistoryTags;
    public event Action<List<string>> HistoryChanged;

    public AdvancedSearchBox()
    {
        InitializeComponents();
        SetupEvents();
    }

    private void InitializeComponents()
    {
        this.rectColor = MPColor.Grey3;
        this.Font = new Font("黑体", 15);

        // 初始化下拉面板
        _dropDownPanel = new UIDropDownPanel();
        _dropDownPanel.Width = BoxWidth;
        _dropDownPanel.MaximumSize = new Size(BoxWidth, 400);
        _dropDownPanel.AutoScroll = false;
        _dropDownPanel.Padding = new Padding(5);
        _dropDownPanel.RectColor = MPColor.Grey3;

        // 初始化建议列表
        suggestionPanel = new Panel();
        suggestionPanel.MaximumSize = new Size(BoxWidth, 370);
        suggestionPanel.Dock = DockStyle.Top;
        suggestionPanel.AutoScroll = true;
        suggestionPanel.Font = new Font("黑体", 15);
        suggestionPanel.Padding = new Padding(5);

        _suggestionList = new ListBox();
        _suggestionList.Dock = DockStyle.Fill;
        _suggestionList.BorderStyle = BorderStyle.None;
        _suggestionList.Cursor = Cursors.Hand;
        _suggestionList.BackColor = MPColor.Grey1;
        suggestionPanel.Controls.Add(_suggestionList);

        // 初始化分隔线
        _separator = new Label();
        _separator.Dock = DockStyle.Top;
        _separator.Height = 1;
        _separator.BackColor = Color.White;
        _separator.Text = "";
        _separator.Visible = false;

        // 初始化历史记录标题 
        _historyLabel = new UILabel();
        _historyLabel.Dock = DockStyle.Top;
        _historyLabel.Text = "历史记录";
        _historyLabel.Font = new Font("黑体", 12, FontStyle.Bold);
        _historyLabel.Margin = new Padding(5);
        _historyLabel.Visible = false;
        _historyLabel.Height = 15;

        // 历史记录面板
        _historyPanel = new FlowLayoutPanel();
        _historyPanel.Dock = DockStyle.Top;
        _historyPanel.Size = new Size(BoxWidth, 35);
        _historyPanel.AutoScroll = true;
        _historyPanel.Padding = new Padding(5);
        _historyPanel.WrapContents = true;
        _historyPanel.BackColor = MPColor.Grey1;

        // 添加底部填充面板确保布局正确
        Panel fillPanel = new Panel();
        fillPanel.Dock = DockStyle.Fill;
        _dropDownPanel.Controls.Add(fillPanel);

        // 组装下拉面板
        _dropDownPanel.Controls.Add(_historyPanel);
        _dropDownPanel.Controls.Add(_historyLabel);
        _dropDownPanel.Controls.Add(_separator);
        _dropDownPanel.Controls.Add(suggestionPanel);
    }

    private void SetupEvents()
    {
        // 添加防抖处理，避免频繁触发搜索建议
        var debouncer = new Debouncer(TimeSpan.FromMilliseconds(100));
        this.TextChanged += async (s, e) =>
        {
            debouncer.Debounce(async () =>
            {
                await UpdateSuggestionsAsync();
            });
        };

        this.KeyDown += (s, e) =>
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchTriggered?.Invoke(this.Text.Trim());
                HideDropDown();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                HideDropDown();
            }
            else if (e.KeyCode == Keys.Down && _suggestionList.Items.Count > 0)
            {
                _suggestionList.Focus();
                _suggestionList.SelectedIndex = 0;
            }
        };

        _suggestionList.KeyDown += (s, e) =>
        {
            if (e.KeyCode == Keys.Enter && _suggestionList.SelectedItem != null)
            {
                this.Text = _suggestionList.SelectedItem.ToString();
                SearchTriggered?.Invoke(this.Text);
                HideDropDown();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                HideDropDown();
            }
        };

        _suggestionList.MouseClick += (s, e) =>
        {
            if (_suggestionList.SelectedItem != null)
            {
                this.Text = _suggestionList.SelectedItem.ToString();
                SearchTriggered?.Invoke(this.Text);
                HideDropDown();
            }
        };
    }

    /*private async Task UpdateSuggestionsAsync()
    {
        if (string.IsNullOrWhiteSpace(this.Text))
        {
            // 如果搜索框为空，只显示历史记录
            await LoadHistoryTagsAsync();
            return;
        }

        try
        {
            // 同时加载建议和历史记录
            var suggestionsTask = GetSuggestions?.Invoke(this.Text) ?? Task.FromResult(new List<string>());
            var historyTask = GetHistoryTags?.Invoke() ?? Task.FromResult(new List<string>());

            await Task.WhenAll(suggestionsTask, historyTask);

            var suggestions = await suggestionsTask;
            var historyTags = await historyTask;

            // 更新UI需要在UI线程上执行
            this.Invoke((MethodInvoker)delegate
            {
                UpdateSuggestionsUI(suggestions, historyTags);
            });
        }
        catch (Exception ex)
        {
            Console.WriteLine($"获取搜索建议失败: {ex.Message}");
        }
    }*/
    private async Task UpdateSuggestionsAsync()
    {
        if (string.IsNullOrWhiteSpace(this.Text))
        {
            // 如果搜索框为空，只显示历史记录
            await LoadHistoryTagsAsync();
            return;
        }

        try
        {
            // 显示加载状态
           // ShowLoadingIndicator();

            // 同时启动加载建议和历史记录的任务
            var suggestionsTask = GetSuggestions?.Invoke(this.Text) ?? Task.FromResult(new List<string>());
            var historyTask = GetHistoryTags?.Invoke() ?? Task.FromResult(new List<string>());

            // 等待两个任务完成
            await Task.WhenAll(suggestionsTask, historyTask);

            // 获取结果
            var suggestions = await suggestionsTask;
            var historyTags = await historyTask;

            // 隐藏加载状态
           // HideLoadingIndicator();

            // 更新UI需要在UI线程上执行
            this.Invoke((MethodInvoker)delegate
            {
                UpdateSuggestionsUI(suggestions, historyTags);
            });
        }
        catch (Exception ex)
        {
            // 隐藏加载状态
            //HideLoadingIndicator();

            Console.WriteLine($"获取搜索建议失败: {ex.Message}");
        }
    }

    private async Task LoadHistoryTagsAsync()
    {
        try
        {
            var historyTags = await (GetHistoryTags?.Invoke() ?? Task.FromResult(new List<string>()));

            this.Invoke((MethodInvoker)delegate
            {
                UpdateHistoryTagsUI(historyTags);

                // 当没有搜索文本时，只显示历史记录
                _suggestionList.Items.Clear();
                suggestionPanel.Height = 0;

                bool hasHistory = historyTags.Count > 0;
                _historyLabel.Visible = hasHistory;
                _historyPanel.Visible = hasHistory;
                _separator.Visible = false;

                _dropDownPanel.Height = hasHistory ? _historyPanel.Height + _historyLabel.Height + 10 : 0;

                if (hasHistory)
                {
                    ShowDropDown();
                }
                else
                {
                    HideDropDown();
                }
            });
        }
        catch (Exception ex)
        {
            Console.WriteLine($"获取历史记录失败: {ex.Message}");
        }
    }

     /*private void UpdateSuggestionsUI(List<string> suggestions, List<string> historyTags)
     {
         bool hasSuggestions = suggestions.Count > 0;
         bool hasHistory = historyTags.Count > 0;

         _suggestionList.Items.Clear();
         _suggestionList.Items.AddRange(suggestions.ToArray());
         _suggestionList.ItemHeight = 20;
         suggestionPanel.Height = Math.Min(suggestions.Count * 20, 200); // 限制最大高度
         _suggestionList.Height = suggestionPanel.Height;

         UpdateHistoryTagsUI(historyTags);

         // 设置历史记录区域可见性
         _historyLabel.Visible = hasHistory;
         _historyPanel.Visible = hasHistory;
         _separator.Visible = hasSuggestions && hasHistory;
         _separator.Height = hasSuggestions && hasHistory ? 1 : 0;

         // 计算并设置下拉面板高度
         int suggestionHeight = hasSuggestions ? suggestionPanel.Height : 0;
         int historyHeight = hasHistory ? _historyPanel.Height : 0;
         int headerHeight = hasHistory ? _historyLabel.Height : 0;
         int separatorHeight = _separator.Visible ? _separator.Height : 0;

         _dropDownPanel.Height = suggestionHeight + separatorHeight + headerHeight + historyHeight + 10; // 10为额外边距

         // 显示下拉面板
         if (hasSuggestions || hasHistory)
         {
             ShowDropDown();
         }
         else
         {
             HideDropDown();
         }
     }*/
    private void UpdateSuggestionsUI(List<string> suggestions, List<string> historyTags)
    {
        bool hasSuggestions = suggestions.Count > 0;
        bool hasHistory = historyTags.Count > 0;

        _suggestionList.Items.Clear();

        if (hasSuggestions)
        {
            _suggestionList.Items.AddRange(suggestions.ToArray());
        }
        else
        {
            // 添加提示行
            _suggestionList.Items.Add("没有匹配结果");
        }

        _suggestionList.ItemHeight = 20;

        // 确保最小高度（即使没有匹配结果，也给点高度）
        int suggestionHeight = Math.Min(Math.Max(suggestions.Count, 1) * 20, 200);
        suggestionPanel.Height = suggestionHeight;
        _suggestionList.Height = suggestionHeight;

        UpdateHistoryTagsUI(historyTags);

        _historyLabel.Visible = hasHistory;
        _historyPanel.Visible = hasHistory;
        _separator.Visible = hasSuggestions && hasHistory;
        _separator.Height = _separator.Visible ? 1 : 0;

        int historyHeight = hasHistory ? _historyPanel.Height : 0;
        int headerHeight = hasHistory ? _historyLabel.Height : 0;
        int separatorHeight = _separator.Visible ? _separator.Height : 0;

        _dropDownPanel.Height = suggestionHeight + separatorHeight + headerHeight + historyHeight + 10; // 10为额外边距

        if (hasSuggestions || hasHistory)
        {
            ShowDropDown();
        }
        else
        {
            HideDropDown();
        }

        // 强制刷新 UI
        _dropDownPanel.Refresh();
    }


    private void UpdateHistoryTagsUI(List<string> historyTags)
    {
        _historyPanel.Controls.Clear();

        foreach (var tag in historyTags)
        {
            var containerPanel = new Panel();
            containerPanel.AutoSize = false;
            containerPanel.Height = 20;
            containerPanel.Margin = new Padding(2, 5, 2, 5);

            var tagLabel = new UIButton();
            tagLabel.Text = tag;
            tagLabel.Style = UIStyle.Custom;
            tagLabel.Dock = DockStyle.Left;
            tagLabel.Font = new Font("黑体", 10);
            tagLabel.Width = TextRenderer.MeasureText(tag, tagLabel.Font).Width + 10;
            tagLabel.FillColor = Color.FromArgb(240, 240, 240);
            tagLabel.RectColor = Color.FromArgb(200, 200, 200);
            tagLabel.ForeColor = Color.Black;
            tagLabel.Cursor = Cursors.Hand;
            tagLabel.Click += (s, e) =>
            {
                this.Text = tag;
                SearchTriggered?.Invoke(tag);
                HideDropDown();
            };

            var deleteButton = new UIButton();
            deleteButton.Text = "✕";
            deleteButton.Style = UIStyle.Custom;
            deleteButton.Dock = DockStyle.Right;
            deleteButton.Width = 13;
            deleteButton.FillColor = Color.FromArgb(240, 240, 240);
            deleteButton.RectColor = Color.FromArgb(200, 200, 200);
            deleteButton.ForeColor = Color.Black;
            deleteButton.Font = new Font(tagLabel.Font.FontFamily, 9, FontStyle.Bold);
            deleteButton.Cursor = Cursors.Hand;
            deleteButton.Click += (s, e) =>
            {
                var currentHistory = new List<string>(historyTags);
                currentHistory.Remove(tag);
                HistoryChanged?.Invoke(currentHistory);
                UpdateHistoryTagsUI(currentHistory);
            };

            containerPanel.Controls.Add(deleteButton);
            containerPanel.Controls.Add(tagLabel);
            containerPanel.Width = tagLabel.Width + deleteButton.Width;
            _historyPanel.Controls.Add(containerPanel);
        }
    }

    public void ShowDropDown()
    {
        if (!_dropDownPanel.Visible)
        {
            _dropDownPanel.Show(this, new Point(0, this.Height));
        }
        Byte_Harmonic.Forms.AppContext.TriggerSearchBoxChange();
    }

    public void HideDropDown()
    {
        _dropDownPanel.Hide();
        Byte_Harmonic.Forms.AppContext.TriggerSearchBoxChange();
    }
}

// 防抖辅助类
public class Debouncer
{
    private readonly TimeSpan _delay;
    private DateTime _lastInvokeTime;
    private System.Threading.Timer _timer;

    public Debouncer(TimeSpan delay)
    {
        _delay = delay;
    }

    public void Debounce(Action action)
    {
        _lastInvokeTime = DateTime.Now;

        _timer?.Dispose();
        _timer = new System.Threading.Timer(_ =>
        {
            if ((DateTime.Now - _lastInvokeTime) >= _delay)
            {
                action();
                _timer.Dispose();
                _timer = null;
            }
        }, null, _delay, Timeout.InfiniteTimeSpan);
    }
}