using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using ZenchenkoProject.Models.Entities;

namespace ZenchenkoProject.Models
{
    public class FillRandomData
    {
        public void FillWarmFloor(ApplicationDbContext context)
        {
            List<List<double>> list = new List<List<double>>();
            list = FillSquareRanges(list);
            for (int i = 0; i < 100; i++)
            {
                context.WarmFloors.AddOrUpdate(new WarmFloor
                {
                    Article= "Кабель нагревательный одножильный Nexans TXLP / 1 300Вт, 17Вт / м",
                    CategoryId = 52,
                    Power = 300,
                    SpaceHeating = "1,8 - 2,2 кв.м",
                    Garanty = 20,
                    Price = 1518,
                    IsInStock = true,
                    CountryOfProduction = "Норвегия",
                    TypeOfWire = TypesOfWire.OneWire,
                    Manufacturer = Manufacturers.Nexans,
                    TypesOfRoom = FillTypesOfRoom(new List<string>()),
                    Ranges = FillSquareRanges(new List<List<double>>()),
                    MethodOfHeat = MethodsOfHeat.Main,
                    MethodOfInstallation = MethodsOfinstallation.InMortar,
                    ConductorOfTheHeating = "двужильный цельнотянутый резистивный проводник",
                    PowerCable = "медный сечением 2х1,0 мм2. Длина 2,25 м",
                    GroundingConductor = "восьмижильный из луженой меди",
                    InsulationOfTheHeatingElement = "сшитый вулканизированный полиэтилен",
                    ProtectScreen = "сплошная алюминиевая трубка",
                    OuterSheald = "ПВХ, синего цвета, устойчивая к ультрафиолетовому излучению",
                    TypeOfConnectionOfHeatingElement = "безмуфтовое соединение",
                    MarkingDirectCoupledConnections = "	«-> SPLICE <-»",
                    WireMarking = "«********»",
                    OuterDiameter = 6.5,
                    LinearPower = "17 Вт/м (при 230В) / 15,6 Вт/м (при 220В)",
                    MinimumBendingRadius = "не меньше пятикратного диаметра кабеля",
                    PermissibleResistanceElement = "-5/+10%",
                    RatedVoltage = 230,
                    TheMaximumVoltage = 500,
                    MaximumTempOfTheOuterShell = 90,
                    MaximumOperatingTempOfHeatingConductor = 65,
                    PictureRef = "http://rdmarket.com.ua/components/com_jshopping/files/img_products/NORDIC_21.jpg",
                    Description= "Готов к монтажу и подключению двужильный кабель с безмуфтовым соединением и алюминиевой защитной трубкой.С одной стороны кабель имеет провод питания длиной 2, 25 м, с другой – герметическое заводское окончание.Для управления необходим терморегулятор."
                });
            }
     

        }
        private List<List<double>> FillSquareRanges(List<List<double>> list)
        {
            list.Add(new List<double>().DoubleRange(0.5, 2.0, 0.1));
            list.Add(new List<double>().DoubleRange(2.1, 3.0, 0.1));
            list.Add(new List<double>().DoubleRange(3.1, 4.0, 0.1));
            list.Add(new List<double>().DoubleRange(4.1, 6.0, 0.1));
            list.Add(new List<double>().DoubleRange(6.1, 9.0, 0.1));
            list.Add(new List<double>().DoubleRange(9.1, 12.0, 0.1));
            list.Add(new List<double>().DoubleRange(12.1, 15.0, 0.1));
            list.Add(new List<double>().DoubleRange(15.1, 26.0, 0.1));
            return list;
        }

        private List<string> FillTypesOfRoom(List<string> list)
        {
            list.Add("Кухня");
            list.Add("Ванная");
            list.Add("Коридор");
            list.Add("Комната");
            list.Add("Балкон");
            list.Add("Санузел");
            return list;
        }
        public void FillNews(ApplicationDbContext context)
        {
            for (int i = 0; i <= 20; i++)
            {
                context.NewsList.Add(new News
                {
                    Title= "Программируемые терморегуляторы помогут экономить на обогреве!!!",
                    ShortDiscription= "С 1 сентября в Украине начался четвертый этап подорожания электрической энергии для населения. Платить придется каждый месяц в среднем на 25 % больше. Это при том, что и прежние тарифы были достаточно высокими.",
                    PreviewPicture= "http://rdmarket.com.ua/images/news/2016/programmable-thermostats/preview/programmable-thermostats-3.jpg",
                    FullPageLink= "~/Views/News/News1.cshtml",
                    DateAdded=DateTime.Now
                });
            }
        }
    }
    public static class ExtensionMethods
    {
        public static List<double> DoubleRange(this List<double> value, double start, double end, double step)
        {
            for (double i = start; i <= end; i = i + step)
            {
                value.Add(Math.Round(i, 2));
            }
            return value;
        }

    }
}
