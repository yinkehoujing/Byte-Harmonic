using Sunny.UI;

public class UIDropDownPanel : UIPanel
{
    public UIDropDownPanel()
    {
        this.Visible = false;
        this.BackColor = Color.White;
        this.Style = UIStyle.Custom;
        this.RectColor = Color.FromArgb(80, 160, 255);
        this.FillColor = Color.White;
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
    private System.Windows.Forms.Timer _searchDelayTimer;

    // 事件定义
    public event Action<string> SearchTriggered;
    public event Func<string, List<string>> GetSuggestions;
    public event Func<List<string>> GetHistoryTags;

    public AdvancedSearchBox()
    {
        InitializeComponents();
        SetupEvents();
    }

    private void InitializeComponents()
    {
        // 初始化下拉面板
        _dropDownPanel = new UIDropDownPanel();
        _dropDownPanel.Style = UIStyle.Custom;
        _dropDownPanel.Width = this.Width;
        _dropDownPanel.MaximumSize = new Size(this.Width, 300);
        _dropDownPanel.AutoScroll = true;

        // 初始化建议列表
        _suggestionList = new ListBox();
        _suggestionList.Dock = DockStyle.Top;
        _suggestionList.Height = 150;
        _suggestionList.Font = new Font("微软雅黑", 10);
        _suggestionList.BorderStyle = BorderStyle.None;

        // 初始化历史记录面板
        _historyPanel = new FlowLayoutPanel();
        _historyPanel.Dock = DockStyle.Fill;
        _historyPanel.AutoSize = true;
        _historyPanel.Padding = new Padding(5);
        _historyPanel.WrapContents = true;

        // 添加分隔线
        var separator = new Label();
        separator.Dock = DockStyle.Top;
        separator.Height = 1;
        separator.BackColor = Color.LightGray;
        separator.Text = "";

        // 添加历史记录标题
        var historyLabel = new UILabel();
        historyLabel.Dock = DockStyle.Top;
        historyLabel.Text = "历史记录";
        historyLabel.Font = new Font("微软雅黑", 9, FontStyle.Bold);
        historyLabel.Margin = new Padding(5, 10, 5, 5);

        // 组装下拉面板
        _dropDownPanel.Controls.Add(_suggestionList);
        _dropDownPanel.Controls.Add(separator);
        _dropDownPanel.Controls.Add(historyLabel);
        _dropDownPanel.Controls.Add(_historyPanel);

        // 初始化延迟搜索计时器
        _searchDelayTimer = new System.Windows.Forms.Timer();
        _searchDelayTimer.Interval = 300; // 300毫秒延迟
        _searchDelayTimer.Tick += (s, e) =>
        {
            _searchDelayTimer.Stop();
            UpdateSuggestions();
        };
    }

    private void SetupEvents()
    {
        this.TextChanged += (s, e) =>
        {
            // 输入变化时启动延迟计时器
            _searchDelayTimer.Stop();
            _searchDelayTimer.Start();
        };

        this.KeyDown += (s, e) =>
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

    private void UpdateSuggestions()
    {
        if (string.IsNullOrWhiteSpace(this.Text))
        {
            HideDropDown();
            return;
        }

        // 获取建议项
        var suggestions = GetSuggestions?.Invoke(this.Text) ?? new List<string>();
        _suggestionList.Items.Clear();
        _suggestionList.Items.AddRange(suggestions.ToArray());

        // 获取历史记录
        var historyTags = GetHistoryTags?.Invoke() ?? new List<string>();
        _historyPanel.Controls.Clear();

        foreach (var tag in historyTags)
        {
            var tagLabel = new UIButton();
            tagLabel.Text = tag;
            tagLabel.Style = UIStyle.Custom;
            tagLabel.Size = new Size(80, 30);
            tagLabel.Margin = new Padding(3);
            tagLabel.Click += (s, e) =>
            {
                this.Text = tag;
                SearchTriggered?.Invoke(tag);
                HideDropDown();
            };
            _historyPanel.Controls.Add(tagLabel);
        }

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
}