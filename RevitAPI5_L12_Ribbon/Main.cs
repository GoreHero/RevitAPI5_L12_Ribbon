using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Visual;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace RevitAPI5_L12_Ribbon
{
    [Transaction(TransactionMode.Manual)]

    public class Main : IExternalApplication //реализуем интерфейс
    {
        public Result OnShutdown(UIControlledApplication application) //при окончании или закрытии
        {
            return Result.Succeeded;
        }

        public Result OnStartup(UIControlledApplication application) //при создание ленты
        {
            string tabName = "Revit API Training";//имя вкладки
            application.CreateRibbonTab(tabName); //создаем вкладку
            string utilsFolderPath = @"C:\Program Files\RevitAPITraining\"; //путь к папке с приложением

            var panel = application.CreateRibbonPanel(tabName, "Пользовательские кнопки"); //панель

            var button = new PushButtonData("Система", "Смена системы труб", 
                Path.Combine(utilsFolderPath, "RevitAPI_L6_IdElement.dll"), "RevitAPI_L6_IdElement.Main");
            panel.AddItem(button);
            var button1 = new PushButtonData("Стены", "Количество и объем",
                Path.Combine(utilsFolderPath, "RevitAPI_W2_ChangeTypeWall.dll"), "RevitAPITrainingUI.Main");
            panel.AddItem(button1);
            var button2 = new PushButtonData("Создание кнопок", "Создание кнопок",
                Path.Combine(utilsFolderPath, "RevitAPI_W1_MadeButton.dll"), "RevitAPI_W2_ChangeTypeWall.Main");
            panel.AddItem(button2);





            return Result.Succeeded;
        }
    }
}
