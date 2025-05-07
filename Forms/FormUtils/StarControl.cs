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
        private readonly ResourceManager _resourceManager;
        private bool _isStared;

        public StarControl(UIImageButton button, ResourceManager resourceManager)
        {
            _button = button ?? throw new ArgumentNullException(nameof(button));
            _resourceManager = resourceManager ?? throw new ArgumentNullException(nameof(resourceManager));
        }

        // 公开方法：初始化按钮图标
        public void InitStarButton(bool initialStaredState = false)
        {
            _isStared = initialStaredState;
            if (_isStared)
            {
                _button.Image = (Image)_resourceManager.GetObject("icons8-christmas-star-100 (2)");
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
            //TODO更改收藏状态
            UpdateButtonImage();
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
                _button.Image = (Image)_resourceManager.GetObject("icons8-christmas-star-100 (2)");
                _button.ImageHover = (Image)_resourceManager.GetObject("icons8-christmas-star-100 (3)");
            }
        }
    }
}
