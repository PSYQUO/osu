﻿using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;
using osu.Game.Graphics;
using osu.Game.Graphics.UserInterface;

namespace osu.Game.Overlays.News
{
    public class NewsHeader : OverlayHeader
    {
        private const string front_page_string = "Front Page";

        private NewsHeaderTitle title;

        public NewsHeader()
        {
            TabControl.AddItem(front_page_string);
        }

        [BackgroundDependencyLoader]
        private void load(OsuColour colour)
        {
            TabControl.AccentColour = colour.Violet;
        }

        protected override Drawable CreateBackground() => new NewsHeaderBackground();

        protected override Drawable CreateContent() => new Container();

        protected override ScreenTitle CreateTitle() => title = new NewsHeaderTitle();

        private class NewsHeaderBackground : Sprite
        {
            public NewsHeaderBackground()
            {
                RelativeSizeAxes = Axes.Both;
                FillMode = FillMode.Fill;
            }

            [BackgroundDependencyLoader]
            private void load(TextureStore textures)
            {
                Texture = textures.Get(@"Headers/news");
            }
        }

        private class NewsHeaderTitle : ScreenTitle
        {
            private const string article_string = "Article";

            public bool IsReadingArticle
            {
                set => Section =  value ? article_string : front_page_string;
            }

            public NewsHeaderTitle()
            {
                Title = "News";
                IsReadingArticle = false;
            }

            protected override Drawable CreateIcon() => new ScreenTitleIcon(@"Icons/news");

            [BackgroundDependencyLoader]
            private void load(OsuColour colours)
            {
                AccentColour = colours.Violet;
            }
        }
    }
}
