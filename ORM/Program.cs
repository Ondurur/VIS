using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIS_Desktop.DataAccessLayer;
using VIS_Desktop.DataAccessLayer.DataMappers;
using VIS_Desktop.DTO;

namespace ORM
{
    class Program
    {
        static void Main(string[] args)
        {
            Database db = new Database();
            db.Connect();

            AkceDataMapper adm = new AkceDataMapper();
            AkceDetiDataMapper addm = new AkceDetiDataMapper();
            DetiDataMapper ddm = new DetiDataMapper();
            FunkceDataMapper fdm = new FunkceDataMapper();
            HodnostiDataMapper hdm = new HodnostiDataMapper();
            RodicDataMapper rdm = new RodicDataMapper();
            SchuzkyDataMapper sdm = new SchuzkyDataMapper();
            VedouciDataMapper vdm = new VedouciDataMapper();
            LogDataMapper ldm = new LogDataMapper();




            DateTime datum = DateTime.Today;

            //Pridani nove akce 1.1, Pokud akce s danym id v databazi existuje tak se jen updatne 1.3
            List<Akce> SelectAkce = adm.SelectAll();
            //Akce novaAkce = new Akce(SelectAkce.Count(), "Nova Akce z Csharp", datum, 0, vdm.SelectById(1), hdm.SelectById(1), 40);

            //Akce pridanaAkce = adm.SelectById(SelectAkce.Count());
            //Console.WriteLine("Pridana akce do databaze:" + pridanaAkce.Aid.ToString() + "|" + pridanaAkce.Nazev.ToString() + "|" + pridanaAkce.Datum_konani.ToString() + "|" + pridanaAkce.Cena.ToString(), pridanaAkce.Hodnosti_hid.Nazev);

            //1.1
            //adm.Insert(novaAkce);
       
            //1.3
            //adm.Update(novaAkce);

            //Select vsech akci 1.4
            Console.WriteLine();
            Console.WriteLine("1.4");
            Console.WriteLine("Aid|Nazev|Datum_konani|Cena|Max_pocet_deti|Vedouci_vid|Hodnosti_hid");
            for (int i = 0; i < SelectAkce.Count(); i++)
            {
                Console.WriteLine(SelectAkce[i].Aid + "|" + SelectAkce[i].Nazev + "|" + SelectAkce[i].Datum_konani + "|" + SelectAkce[i].Cena + "|" + SelectAkce[i].Max_pocet_deti + "|" + SelectAkce[i].Vedouci_vid.Vid + "|" + SelectAkce[i].Hodnosti_hid.Hid);
            }


            //Pridani noveho vedouciho 2.1, pokud vedouci s danym id v databazi neexistuje tak se provede update nad danym id 2.3
            List<Rodic> SelectRodic = rdm.SelectAll();
            //Rodic novyRodic = new Rodic(SelectRodic.Count()+1, "Novy rodic z Csharp", "CSHARPLOGIN", "CSHARPPW", "randommail@csharp.com");
            //rdm.Insert(novyRodic);

            Rodic pridanyRodic = rdm.SelectById(SelectRodic.Count());
            //Console.WriteLine("Pridany rodic do databaze:" + pridanyRodic.Rid + "|" + pridanyRodic.Jmeno + "|" + pridanyRodic.Login + "|" + pridanyRodic.Heslo + "|" + pridanyRodic.Kontakt);

            //Odebrani rodice 2.2
            //rdm.Delete(pridanyRodic);

            //2.3
            //rdm.Update(novyRodic);

            //Select vsech vedoucich 2.4
            Console.WriteLine();
            Console.WriteLine("2.4");
            Console.WriteLine("rid|jmeno|login|heslo|kontakt");
            for (int i = 0; i < SelectRodic.Count(); i++)
            {
                Console.WriteLine(SelectRodic[i].Rid + "|" + SelectRodic[i].Jmeno + "|" + SelectRodic[i].Login + "|" + SelectRodic[i].Heslo + "|" + SelectRodic[i].Kontakt);
            }
            

            //Pridani noveho ditete 3.1
            List<Deti> SelectDeti = ddm.SelectAll();
            //Deti noveDite = new Deti(SelectDeti.Count()+1,"Nove dite", "NvDt", "NvDtPw", datum, 0, hdm.SelectById(1),sdm.SelectById(1),0, rdm.SelectById(1));
            //ddm.Insert(noveDite);

            //3.2
            //ddm.Delete(noveDite);

            //3.3
            //ddm.Update(noveDite);

            //3.4

            Console.WriteLine();
            Console.WriteLine("3.4");
            Console.WriteLine("did|jmeno|nickname|heslo|datum narozeni|stav|hodnost|schuzky|registrovanych akci|rodic");
            for (int i = 0; i < SelectDeti.Count(); i++)
            {
                Console.WriteLine(SelectDeti[i].Did + "|" + SelectDeti[i].Jmeno + "|" + SelectDeti[i].Nickname + "|" + SelectDeti[i].Heslo + "|" + SelectDeti[i].Datum_narozeni + "|" + SelectDeti[i].Stav + "|" + SelectDeti[i].Hodnosti_hid.Hid + "|" + SelectDeti[i].Schuzky_sid.Sid + "|" + SelectDeti[i].Reg_akci + "|" + SelectDeti[i].Rodic_rid.Rid);
            }

            //3.5 - Netrivialni select

            Console.WriteLine();
            Console.WriteLine("3.5");
            List<Tuple<int, string, int, int>> ret = ddm.NejpocetnejsiAkce();
            for(int i = 0; i< ret.Count(); i++)
            {
                Console.WriteLine(ret[i].Item1 + "|" + ret[i].Item2 + "|" + ret[i].Item3 + "|" + ret[i].Item4);
            }


            //4.1 - funkce (stored procedure)
            //fdm.NovaFunkce("random funkce", random povinnosti");

            //4.4

            Console.WriteLine();
            Console.WriteLine("4.4");
            List<Funkce> SelectFunkce = fdm.SelectAll();

            Console.WriteLine("fid|nazev|povinnosti");
            for (int i = 0; i < SelectFunkce.Count(); i++)
            {
                Console.WriteLine(SelectFunkce[i].Fid + "|" + SelectFunkce[i].Nazev + "|" + SelectFunkce[i].Povinnosti);
            }

            //4.3
            /*Funkce f = SelectFunkce[SelectFunkce.Count() - 1];
            f.Povinnosti = "zmena povinnosti";
            fdm.Update(f);
            */

            //5.1 - schuzky
            List<Schuzky> SelectSchuzky = sdm.SelectAll();
            //Schuzky novaSchuzka = new Schuzky(SelectAkce.Count(), "Nova schuzka", 12, 4, vdm.SelectById(1));
            //sdm.Insert(novaSchuzka);

            //5.3
            //sdm.Update(novaSchuzka);

            //5.4

            Console.WriteLine();
            Console.WriteLine("5.4");
            Console.WriteLine("sid|nazev_druziny|pocet_deti|datum_konani|vedouci_vid");
            for (int i = 0; i < SelectSchuzky.Count(); i++)
            {
                Console.WriteLine(SelectSchuzky[i].Sid + "|" + SelectSchuzky[i].Nazev + "|" + SelectSchuzky[i].Pocet_Deti + "|" + SelectSchuzky[i].Datum_konani + "|" + SelectSchuzky[i].Vedouci_vid.Vid);
            }

            Console.WriteLine();
            Console.WriteLine("5.5");
            //5.5
             List<Tuple<Deti,Schuzky>> DetiSchuzky = sdm.SelectWithDeti();
            for (int i = 0; i < DetiSchuzky.Count(); i++)
            {
                Console.WriteLine(DetiSchuzky[i].Item2.Nazev + "|" + DetiSchuzky[i].Item1.Jmeno);
            }

            //6.1 - vedouci
            List<Vedouci> SelectVedouci = vdm.SelectAll();
            //Vedouci novyVedouci = new Vedouci(SelectVedouci.Count()+1, "Novy Vedouci", "NewPwVedouci", datum, "mejlnovehovedouciho@mejl", null);
            //vdm.Insert(novyVedouci);

            //6.2
            //vdm.Delete(novyVedouci);

            //6.3
            //vdm.Update(novyVedouci);

            //6.4
            Console.WriteLine();
            Console.WriteLine("6.4");
            Console.WriteLine("vid|jmeno|heslo|datum_narozeni|kontakt|funkce_fid");
            for (int i = 0; i < SelectVedouci.Count(); i++)
            {
                Console.WriteLine(SelectVedouci[i].Vid + "|" + SelectVedouci[i].Jmeno + "|" + SelectVedouci[i].Heslo + "|" + SelectVedouci[i].Datum_narozeni + "|" + SelectVedouci[i].Kontakt + "|" + SelectVedouci[i].Funkce_fid.Fid);
            }

            //6.5 - StoredProcedure
            //vdm.DiteBecomeVedouci(1);

            //6.6 - netrivialni select

            Console.WriteLine();
            Console.WriteLine("6.6");
            var test = vdm.VedouciSchuzkaDite(5);
            Console.WriteLine(test.Item1 + "|" + test.Item2 + "|" + test.Item3);

            //7.1 - Hodnost
            List<Hodnosti> SelectHodnosti = hdm.SelectAll();
            Hodnosti NovaHodnost = new Hodnosti(SelectHodnosti.Count(), "Nova Hodnost", 8);
            //hdm.Insert(NovaHodnost);

            //7.3
            //hdm.Update(NovaHodnost);

            //7.4
            Console.WriteLine();
            Console.WriteLine("7.4");
            for (int i = 0; i < SelectHodnosti.Count(); i++)
            {
                Console.WriteLine(SelectHodnosti[i].Hid + "|" + SelectHodnosti[i].Nazev + "|" + SelectHodnosti[i].Minimalni_vek);
            }

            //8.1 - log
            //ldm.MakeLog(1);

            //8.3
            List<Log> SelectLog = ldm.SelectAll();
            //Log NovyLog = new Log(SelectLog.Count(), SelectDeti.Count(), SelectVedouci.Count(), datum, vdm.SelectById(1));
            //ldm.Update(NovyLog);

            //8.4
            Console.WriteLine();
            Console.WriteLine("8.4");
            Console.WriteLine("lid|pocet_deti|pocet_vedoucich|datum_zalohy|vedouci_vid");
            for (int i = 0; i < SelectLog.Count(); i++)
            {
                Console.WriteLine(SelectLog[i].Lid + "|" + SelectLog[i].Pocet_deti + "|" + SelectLog[i].Pocet_vedoucich + "|" + SelectLog[i].Datum_zalohy + "|" + SelectLog[i].Vedouci_vid.Vid);
            }

            //9.1 - akcedeti (Stored Procedure)
            //addm.AddAkceToDite(1, 4);

            List<AkceDeti> SelectAkceDeti = addm.SelectAll();
            AkceDeti NoveAkceDeti = new AkceDeti(1, 4);

            //9.2
            //addm.Delete(NoveAkceDeti);


            //9.4
            Console.WriteLine();
            Console.WriteLine("9.4");
            Console.WriteLine("akce_aid|deti_did");
            for (int i = 0; i < SelectAkceDeti.Count(); i++)
            {
                Console.WriteLine(SelectAkceDeti[i].Akce_aid + "|" + SelectAkceDeti[i].Deti_did);
            }

            Console.ReadLine();
        }
    }
}
