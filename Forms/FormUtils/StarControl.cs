using Byte_Harmonic.Properties;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace Byte_Harmonic.Forms.FormUtils
{
    class StarControl
    {
        private readonly UIImageButton _button;
        private readonly ResourceManager _resourceManager = new ResourceManager("Byte_Harmonic.Properties.Resources", typeof(Resources).Assembly);//获取全局资源
        private bool _isStared;

        public StarControl(UIImageButton button)
        {
            _button = button ?? throw new ArgumentNullException(nameof(button));
            _resourceManager = new ResourceManager("Byte_Harmonic.Properties.Resources", typeof(Resources).Assembly);//获取全局资源
        }

        // 公开方法：初始化按钮图标
        public void InitStarButton(bool initialStaredState = false)
        {
            _isStared = initialStaredState;
            if (_isStared)
            {
                _button.Image = (Image)_resourceManager.GetObject("icons8-星-100");
                _button.ImageHover = (Image)_resourceManager.GetObject("icons8-christmas-star-100 (3)");
            }
            else
            {
                _button.Image = (Image)_resourceManager.GetObject("icons8-christmas-star-100");
                _button.ImageHover = (Image)_resourceManager.GetObject("icons8-christmas-star-100 (1)");
            }
        }

        // 公开方法：绑定点击事件
        public void StarButtonClick(object sender, EventArgs e)
        {
            _isStared = !_isStared;
            
            UpdateButtonImage();//更改显示收藏状态

            AppContext.TriggerFavoriteUpdated();
        }

        // 私有方法：更新按钮图标
        private void UpdateButtonImage()
        {
            if (_isStared)
            {
                _button.Image = (Image)_resourceManager.GetObject("icons8-christmas-star-100");
                _button.ImageHover = (Image)_resourceManager.GetObject("icons8-christmas-star-100 (1)");
            }
            else
            {
                _button.Image = (Image)_resourceManager.GetObject("icons8-星-100");
                _button.ImageHover = (Image)_resourceManager.GetObject("icons8-christmas-star-100 (3)");
            }
        }
    }
}
