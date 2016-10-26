using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapeos.Negocio
{
    public class Severidades
    {
        public int Id_Severidades { get; set; }
        public int Data { get; set; }
        public string Destination_Table_Name { get; set; }
        public string Source_Column_Name { get; set; }
        public int Fuente_Destino { get; set; }
        public string Ref_Table_Name { get; set; }
        public string Ref_Column_Name { get; set; }
        public int Business_Rule_Cd { get; set; }
        public string Business_Rule_Desc { get; set; }
        public int Id_Quality_Type { get; set; }
        public bool Estado { get; set; }
        public int Numero_Fuente { get; set; }

        public Severidades()
        {
            this.Init();
        }

        private void Init()
        {
            Id_Severidades = 0;
            Data = 0;
            Destination_Table_Name = string.Empty;
            Source_Column_Name = string.Empty;
            Fuente_Destino = 0;
            Ref_Table_Name = string.Empty;
            Ref_Column_Name = string.Empty;
            Business_Rule_Cd = 0;
            Business_Rule_Desc = string.Empty;
            Id_Quality_Type = 0;
            Estado = true;
            Numero_Fuente = 0;
        }

        public bool Read()
        {
            try
            {
                DALC.severidades fue = CommonBC.Modelo.severidades.First(f => f.id_severidades == Id_Severidades);

                Id_Severidades = fue.id_severidades;
                Data = fue.data_fuente;
                Destination_Table_Name = fue.destination_table_name;
                Source_Column_Name = fue.source_column_name;
                Fuente_Destino = fue.fuente_destino;
                Ref_Table_Name = fue.ref_table_name;
                Ref_Column_Name = fue.ref_column_name;
                Business_Rule_Cd = fue.business;
                Business_Rule_Desc = fue.buss_rule_desc;
                Id_Quality_Type = fue.id_quality_type;
                Estado = fue.estado;
                Numero_Fuente = fue.numero_fuente;

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }



        public bool Create()
        {
            try
            {
                DALC.severidades fue = new DALC.severidades();

                fue.id_severidades = Id_Severidades;
                fue.numero_fuente = Numero_Fuente;
                fue.data_fuente = Data;
                fue.destination_table_name = Destination_Table_Name;
                fue.source_column_name = Source_Column_Name;
                fue.fuente_destino = Fuente_Destino;
                fue.ref_table_name = Ref_Table_Name;
                fue.ref_column_name = Ref_Column_Name;
                fue.business = Business_Rule_Cd;
                fue.buss_rule_desc = Business_Rule_Desc;
                fue.id_quality_type = Id_Quality_Type;
                fue.estado = Estado;

                CommonBC.Modelo.severidades.AddObject(fue);
                CommonBC.Modelo.SaveChanges();

                return true;
            }
            catch(Exception ex)
            {
                return false;
            }           
            
        }

        public bool Update()
        {
            try
            {
                DALC.severidades fue = CommonBC.Modelo.severidades.First(f => f.id_severidades == Id_Severidades);

                fue.id_severidades = Id_Severidades;
                fue.numero_fuente = Numero_Fuente;
                fue.data_fuente = Data;
                fue.destination_table_name = Destination_Table_Name;
                fue.source_column_name = Source_Column_Name;
                fue.fuente_destino = Fuente_Destino;
                fue.ref_table_name = Ref_Table_Name;
                fue.ref_column_name = Ref_Column_Name;
                fue.business = Business_Rule_Cd;
                fue.buss_rule_desc = Business_Rule_Desc;
                fue.id_quality_type = Id_Quality_Type;
                fue.estado = Estado;

                CommonBC.Modelo.SaveChanges();

                return true;
            }catch(Exception ex){

                return false;
            }
        }

        public bool Delete()
        {
            try
            {
                DALC.severidades fue = CommonBC.Modelo.severidades.First(f => f.id_severidades == Id_Severidades);
                CommonBC.Modelo.severidades.DeleteObject(fue);
                CommonBC.Modelo.SaveChanges();

                return true;
            }catch(Exception ex)
            {
                return false;
            }

        }


    }
}
