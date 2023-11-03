using FirmaMAUI.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FirmaMAUI.ViewModels.Client
{
    public class RuvViewModel : ViewModelBase
    {
        public RuvViewModel() {
        }


        private string _jsonFase1;
        public string JsonFase1
        {
            get => _jsonFase1;
            set => SetProperty(ref _jsonFase1, value);
        }

        private string _jsonFase2;
        public string JsonFase2
        {
            get => _jsonFase2;
            set => SetProperty(ref _jsonFase2, value);
        }

        private string _jsonFase3;
        public string JsonFase3
        {
            get => _jsonFase3;
            set => SetProperty(ref _jsonFase3, value);
        }

        private string _jsonFase6;
        public string JsonFase6
        {
            get => _jsonFase6;
            set => SetProperty(ref _jsonFase6, value);
        }

        private int _totalVacunadosAftosa = 0;
        public int TotalVacunadosAftosa
        {
            get => _totalVacunadosAftosa;
            set => SetProperty(ref _totalVacunadosAftosa, value);
        }

        private int _totalNoVacunadosAftosa = 0;
        public int TotalNoVacunadosAftosa
        {
            get => _totalNoVacunadosAftosa;
            set => SetProperty(ref _totalNoVacunadosAftosa, value);
        }

        private int _totalVacunadosBrucelosis = 0;
        public int TotalVacunadosBrucelosis
        {
            get => _totalVacunadosBrucelosis;
            set => SetProperty(ref _totalVacunadosBrucelosis, value);
        }

        private int _totalNoVacunadosBrucelosis = 0;
        public int TotalNoVacunadosBrucelosis
        {
            get => _totalNoVacunadosBrucelosis;
            set => SetProperty(ref _totalNoVacunadosBrucelosis, value);
        }

        public override async Task InitializeAsync(object navigationData)
        {
            await base.InitializeAsync(navigationData);
            LoadJson();
        }

        public void LoadJson()
        {
            JsonFase1 = "[{" +
            "'label': 'Organización Ejecutora Ganadera Autorizada'," +
            "'type': 'Entry'" +
            "},{" +
            "'label': 'Código (OEGA)'," +
            "'type': 'Entry'" +
            "},{" +
            "'label':'Oficina Local ICA'," +
            "'type':'Entry'" +
            "}" +
            ",{" +
            "'label':'Código (Ofinica Local ICA)'," +
            "'type':'Entry'" +
            "},{" +
            "'label':'Proyecto Local'," +
            "'type':'Entry'" +
            "},{" +
            "'label':'Código (Proyecto Local)'," +
            "'type':'Entry'" +
            "},{" +
            "'label':'Estado Del Ruv'," +
            "'type':'Entry'" +
            "}]";
        }

        public void LoadJsonFase2()
        {
            JsonFase2 = "[{" +
            "'label':'Periodo nuevo'," +
            "'type':'radioButtom'," +
            "'isTrue':'true'" +
            "}," +
            "{" +
            "'label':'Zona'," +
            "'type':'radioButtom'," +
            "'isTrue':'true'," +
            "'zone':'true'" +
            "},{" +
            "'label': 'Código del Predio'," +
            "'type': 'Entry'" +
            "},{" +
            "'label':'Nombre del Predio'," +
            "'type':'Entry'" +
            "}," +
            "{" +
            "'label':'departamento del Predio'," +
            "'type':'Entry'" +
            "},{" +
            "'label':'Municipio del Predio'," +
            "'type':'Entry'" +
            "},{" +
            "'label':'Vereda / Localidad o Comuna'," +
            "'type':'Entry'" +
            "},{" +
            "'label':'Código (Departamento)'," +
            "'type':'Entry'" +
            "}" +
            ",{" +
            "'label':'Código (Municipio)'," +
            "'type':'Entry'" +
            "}," +
            "{" +
            "'label':'Código (Vereda / Localidad o Comuna)'," +
            "'type':'Entry'" +
            "}]";
        }

        public void LoadJsonFase3()
        {
            JsonFase3 = "[{" +
            "'label': 'Número'," +
            "'type': 'Entry'" +
            "},{" +
            "'label': 'Nombre del Ganadero o Razón Social'," +
            "'type': 'Entry'" +
            "}," +
            "{" +
            "'label':'Sexo del Ganadero'," +
            "'type':'radioButtom'," +
            "'gender':'true'," +
            "},{" +
            "'label': 'Identificación'," +
            "'type': 'Entry'" +
            "},{" +
            "'label':'Teléfono'," +
            "'type':'Entry'" +
            "}" +
            ",{" +
            "'label':'Correo Electrónico'," +
            "'type':'Entry'" +
            "}]";
        }

        public void LoadJson6()
        {
            JsonFase6 = "{\"Vacunas\":[{\"Id\":\"1\",\"Nombre\":\"BRUCELOSIS\",\"IdCategoriaEtaria\":[\"2\",\"8\"]},{\"Id\":\"1\",\"Nombre\":\"AFTOSA\",\"IdCategoriaEtaria\":[\"1\",\"2\",\"8\",\"11\"]}],\"Etaria\":[{\"Id\":\"1\",\"Categoria\":\"HEMBRA DE 1 A 3 MESES\"},{\"Id\":\"2\",\"Categoria\":\"HEMBRA DE 3 A 9 MESES\"},{\"Id\":\"3\",\"Categoria\":\"HEMBRA DE 12 MESES A 2 AÑOS\"},{\"Id\":\"8\",\"Categoria\":\"MACHO DE 2 A 3 MESES\"},{\"Id\":\"9\",\"Categoria\":\"MACHO DE 3 A 9 MESES\"},{\"Id\":\"11\",\"Categoria\":\"MACHO DE 12 MESES A 2 AÑOS\"},{\"Id\":\"12\",\"Categoria\":\"NUEVOS\"}]}";
        }
    }
}
