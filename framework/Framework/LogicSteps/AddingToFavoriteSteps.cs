using Framework.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.LogicSteps
{
    public  class AddingToFavoriteSteps
    {
        public static string Journal;
        public static string FirstArticleTitle;
        public static string FolderName;

        public static void GoToFirstJournal(ListOfJournalsPage listPage)
        {
            Journal = listPage.FirstJournal.Text;
            listPage.FirstJournal.Click();
        }

        public static void ClickFavorite(CurrentJournalPage current)
        {
            FirstArticleTitle = current.Articles.FindElements()[0].GetAttribute("title");
            current.FavoriteButton.Click();
        }

        public static void GoToListOfArticles(CurrentJournalPage page, ArticlePage articlePage)
        {
            FirstArticleTitle = page.Articles.FindElements()[0].GetAttribute("title");
            page.Articles.FindElements()[0].Click();
            articlePage.AddToFavoriteButtons.FindElements()[1].Click();
        }

        public static void ToNewFolder(SelectFolderForm form, string folderName)
        {
            form.NewFolderButton.Click();
            form.NewFolderBox.SendKeys(folderName);
            FolderName = folderName;
            form.SubmitButton.Click();
            form.GoToMyFavoriteButton.Click();
        }

        public static void ToExistingFolder(SelectFolderForm form)
        {
            form.ExistingFolderButton.Click();
            FolderName = form.ExistingFoldersBox.FindElements()[0].Text;
            form.SubmitButton.Click();
            form.GoToMyFavoriteButton.Click();
        }
        public static bool IsAddedRight(MyFavoritePage page, string folder, string article)
        {
            return page.IsRightFolder(folder) && page.IsExistArticle(article);
        }

        public static void Delete(MyFavoritePage page)
        {
            page.DeleteButton.Click();
            page.ConfirmDeleteButton.Click();
        }

    }
}
