// AUTOMATICALLY GENERATED CODE

using System;
using System.Collections.Generic;
using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Imaging;
using Sce.PlayStation.Core.Environment;
using Sce.PlayStation.HighLevel.UI;

namespace Blimp
{
    partial class Enter_IP
    {
        Label IP_label;
        EditableText EditableText_1;
        Button Button_1;

        private void InitializeWidget()
        {
            InitializeWidget(LayoutOrientation.Horizontal);
        }

        private void InitializeWidget(LayoutOrientation orientation)
        {
            IP_label = new Label();
            IP_label.Name = "IP_label";
            EditableText_1 = new EditableText();
            EditableText_1.Name = "EditableText_1";
            Button_1 = new Button();
            Button_1.Name = "Button_1";

            // IP_label
            IP_label.TextColor = new UIColor(0f / 255f, 0f / 255f, 0f / 255f, 255f / 255f);
            IP_label.Font = new UIFont(FontAlias.System, 25, FontStyle.Regular);
            IP_label.LineBreak = LineBreak.Character;
            IP_label.HorizontalAlignment = HorizontalAlignment.Center;
            IP_label.TextShadow = new TextShadowSettings()
            {
                Color = new UIColor(128f / 255f, 128f / 255f, 128f / 255f, 127f / 255f),
                HorizontalOffset = 2f,
                VerticalOffset = 2f,
            };

            // EditableText_1
            EditableText_1.TextColor = new UIColor(0f / 255f, 0f / 255f, 0f / 255f, 255f / 255f);
            EditableText_1.Font = new UIFont(FontAlias.System, 25, FontStyle.Regular);
            EditableText_1.LineBreak = LineBreak.Character;

            // Button_1
            Button_1.TextColor = new UIColor(68f / 255f, 8f / 255f, 8f / 255f, 255f / 255f);
            Button_1.TextFont = new UIFont(FontAlias.System, 25, FontStyle.Regular);
            Button_1.BackgroundFilterColor = new UIColor(240f / 255f, 208f / 255f, 208f / 255f, 153f / 255f);

            // Enter_IP
            this.RootWidget.AddChildLast(IP_label);
            this.RootWidget.AddChildLast(EditableText_1);
            this.RootWidget.AddChildLast(Button_1);

            SetWidgetLayout(orientation);

            UpdateLanguage();
        }

        private LayoutOrientation _currentLayoutOrientation;
        public void SetWidgetLayout(LayoutOrientation orientation)
        {
            switch (orientation)
            {
                case LayoutOrientation.Vertical:
                    this.DesignWidth = 544;
                    this.DesignHeight = 960;

                    IP_label.SetPosition(386, 136);
                    IP_label.SetSize(214, 36);
                    IP_label.Anchors = Anchors.None;
                    IP_label.Visible = true;

                    EditableText_1.SetPosition(316, 233);
                    EditableText_1.SetSize(360, 56);
                    EditableText_1.Anchors = Anchors.None;
                    EditableText_1.Visible = true;

                    Button_1.SetPosition(540, 231);
                    Button_1.SetSize(214, 56);
                    Button_1.Anchors = Anchors.None;
                    Button_1.Visible = true;

                    break;

                default:
                    this.DesignWidth = 960;
                    this.DesignHeight = 544;

                    IP_label.SetPosition(253, 149);
                    IP_label.SetSize(411, 36);
                    IP_label.Anchors = Anchors.None;
                    IP_label.Visible = true;

                    EditableText_1.SetPosition(253, 231);
                    EditableText_1.SetSize(319, 54);
                    EditableText_1.Anchors = Anchors.None;
                    EditableText_1.Visible = true;

                    Button_1.SetPosition(584, 231);
                    Button_1.SetSize(84, 56);
                    Button_1.Anchors = Anchors.None;
                    Button_1.Visible = true;

                    break;
            }
            _currentLayoutOrientation = orientation;
        }

        public void UpdateLanguage()
        {
            IP_label.Text = "Enter destination IP address:";

            EditableText_1.Text = "Edit";

            Button_1.Text = "GO";
        }

        private void onShowing(object sender, EventArgs e)
        {
            switch (_currentLayoutOrientation)
            {
                case LayoutOrientation.Vertical:
                    break;

                default:
                    break;
            }
        }

        private void onShown(object sender, EventArgs e)
        {
            switch (_currentLayoutOrientation)
            {
                case LayoutOrientation.Vertical:
                    break;

                default:
                    break;
            }
        }

    }
}
