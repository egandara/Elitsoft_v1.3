using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapeos.Negocio
{
    public class Colecciones
    {
        public List<Periodicidad> Periodicidad_ReadAll()
        {
            return PeriodicidadGenerarListado(CommonBC.Modelo.periodicidad.ToList());
        }

        private List<Periodicidad> PeriodicidadGenerarListado(List<DALC.periodicidad> listaDALC)
        {
            List<Periodicidad> listaBC = new List<Periodicidad>();
            foreach (DALC.periodicidad i in listaDALC)
            {
                Periodicidad per = new Periodicidad()
                {
                    Id_Periodicidad = i.id_periodicidad,
                    Nombre_Periodicidad = i.nombre_periodicidad
                };
                listaBC.Add(per);
            }
            return listaBC;
        }

        public List<Extractor> Extractor_ReadAll()
        {
            return ExtractorGenerarListado(CommonBC.Modelo.extractor.ToList());
        }

        private List<Extractor> ExtractorGenerarListado(List<DALC.extractor> listaDALC)
        {
            List<Extractor> listaBC = new List<Extractor>();
            foreach (DALC.extractor i in listaDALC)
            {
                Extractor ext = new Extractor()
                {
                    Id_Extractor = i.id_extractor,
                    Nombre_Extractor = i.nombre_extractor
                };
                listaBC.Add(ext);
            }
            return listaBC;
        }

        public List<Fuentes> DescripcionFuente_ReadAll()
        {
            return DescripcionFuenteGenerarListado(CommonBC.Modelo.desc_fuente.ToList());
        }

        private List<Fuentes> DescripcionFuenteGenerarListado(List<DALC.desc_fuente> listaDALC)
        {
            List<Fuentes> listaBC = new List<Fuentes>();
            foreach (DALC.desc_fuente i in listaDALC)
            {
                Fuentes fue = new Fuentes()
                {
                    Numero_Fuente = i.numero_fuente,
                    Archivo_Fuente = i.archivo_fuente,
                    Sistema_Fuente = i.sistema_fuente,
                    Contenido = i.contenido,
                    Cantidad_Registros = i.cantidad_registros,
                    Periodicidad = i.id_periodicidad,
                    Tipo_Extractor = i.id_extractor,
                    Nombre = i.nombre
                };
                listaBC.Add(fue);
            }
            return listaBC;
        }

        public List<Relacion> RelacionReadAll()
        {
            return RelacionGenerarListado(CommonBC.Modelo.relacion.ToList());
        }

        private List<Relacion> RelacionGenerarListado(List<DALC.relacion> listaDALC)
        {
            List<Relacion> listaBC = new List<Relacion>();
            foreach (DALC.relacion i in listaDALC)
            {
                Relacion rel = new Relacion()
                {
                    Id_Tipo_Relacion = i.id_tipo_relacion,
                    Numero_Fuente = i.numero_fuente,
                    Numero_Fuente_Relacionada = i.numero_fuente_relacionada
                };
                listaBC.Add(rel);
            }
            return listaBC;
        }

        public List<Tipo_Relacion> TipoRelacionReadAll()
        {
            return TipoRelacionGenerarListado(CommonBC.Modelo.tipo_relacion.ToList());
        }

        private List<Tipo_Relacion> TipoRelacionGenerarListado(List<DALC.tipo_relacion> listaDALC)
        {
            List<Tipo_Relacion> listaBC = new List<Tipo_Relacion>();
            foreach (DALC.tipo_relacion i in listaDALC)
            {
                Tipo_Relacion tip = new Tipo_Relacion()
                {
                    IdTipoRelacion = i.id_tipo_relacion,
                    NombreTipoRelacion = i.nombre
                };
                listaBC.Add(tip);
            }
            return listaBC;
        }

        public string NombreFuentePorId(int idFuente)
        {
            string Nombre = (from f in DescripcionFuente_ReadAll()
                             where f.Numero_Fuente == idFuente
                             select f.Nombre).Single().ToString();
            return Nombre;
        }

        public int IdFuentePorNombre(string nombreFuente)
        {
            int Id = (from f in DescripcionFuente_ReadAll()
                      where f.Nombre == nombreFuente
                      select f.Numero_Fuente).Single();
            return Id;
        }

        public object ListaRelacionesPrecedenciasPorId(int idFuente)
        {
            var query = (from r in RelacionReadAll()
                         join t in TipoRelacionReadAll() on r.Id_Tipo_Relacion equals t.IdTipoRelacion
                         where r.Numero_Fuente == idFuente && r.Id_Tipo_Relacion == 1
                         select NombreFuentePorId(r.Numero_Fuente_Relacionada)).ToList();
            return query;
        }

        public object ListaRelacionesDestinosPorId(int idFuente)
        {
            var query = (from r in RelacionReadAll()
                         join t in TipoRelacionReadAll() on r.Id_Tipo_Relacion equals t.IdTipoRelacion
                         where r.Numero_Fuente == idFuente && r.Id_Tipo_Relacion == 2
                         select NombreFuentePorId(r.Numero_Fuente_Relacionada)).ToList();
            return query;
        }


        public object ListaRelacionesMinorPorId(int idFuente)
        {
            var query = (from r in RelacionReadAll()
                         join t in TipoRelacionReadAll() on r.Id_Tipo_Relacion equals t.IdTipoRelacion
                         where r.Numero_Fuente == idFuente && r.Id_Tipo_Relacion == 3
                         select NombreFuentePorId(r.Numero_Fuente_Relacionada)).ToList();
            return query;
        }

        public string NombrePeriodicidadPorId(int idPeriodicidad)
        {
            string Nombre = (from p in Periodicidad_ReadAll()
                            where p.Id_Periodicidad == idPeriodicidad
                            select p.Nombre_Periodicidad).Single();
            return Nombre;
        }

        public string NombreExtractorPorId(int idExtractor)
        {
            string Nombre = (from e in Extractor_ReadAll()
                             where e.Id_Extractor == idExtractor
                             select e.Nombre_Extractor).Single();
            return Nombre;
        }

        public int IdPeriodicidadPorNombre(string nombrePeriodicidad)
        {
            int Id = (from p in Periodicidad_ReadAll()
                      where p.Nombre_Periodicidad == nombrePeriodicidad
                      select p.Id_Periodicidad).Single();
            return Id;
        }

        public int IdExtractorPorNombre(string nombreExtractor)
        {
            int Id = (from e in Extractor_ReadAll()
                      where e.Nombre_Extractor == nombreExtractor
                      select e.Id_Extractor).Single();
            return Id;
        }

        public List<Usuario> Usuario_ReadAll()
        {
            return Usuario_GenerarListado(CommonBC.Modelo.login.ToList());
        }

        private List<Usuario> Usuario_GenerarListado(List<DALC.login> listaDALC)
        {
            List<Usuario> listaBC = new List<Usuario>();
            foreach (DALC.login i in listaDALC)
            {
                Usuario usu = new Usuario()
                {
                    Rut = i.rut,
                    Dv = char.Parse(i.dv),
                    Nombre = i.nombre_usuario,
                    UserName = i.usuario,
                    Clave = i.clave,
                    Tipo_Usuario = i.id_tipo_usuario,
                    Estado = i.estado
                };
                listaBC.Add(usu);
            }
            return listaBC;
        }

        public List<TipoUsuario> TipoUsuario_ReadAll()
        {
            return TipoUsuario_GenerarListado(CommonBC.Modelo.tipo_usuario.ToList());
        }

        private List<TipoUsuario> TipoUsuario_GenerarListado(List<DALC.tipo_usuario> listaDALC)
        {
            List<TipoUsuario> listaBC = new List<TipoUsuario>();
            foreach (DALC.tipo_usuario i in listaDALC)
            {
                TipoUsuario tip = new TipoUsuario()
                {
                    Id_Tipo_Usuario = i.id_tipo_usuario,
                    Nombre_Tipo = i.descripcion
                };
                listaBC.Add(tip);
            }
            return listaBC;
        }

        public List<int> ListaCompletaFuente()
        {
            var lista = CommonBC.Modelo.desc_fuente.Select(f => f.numero_fuente);
            return lista.ToList();
        }

        //Precedencias
        public List<int> FuentesPrecedencias(int idFuente)
        {
            var lista = CommonBC.Modelo.relacion.Where(r => r.numero_fuente == idFuente && r.id_tipo_relacion == 1).Select(r => r.numero_fuente_relacionada);
            return lista.ToList();
        }

        public List<int> ListaPrecedenciasNoAsociadas(int idFuente)
        {
            var lista = ListaCompletaFuente().Except(FuentesPrecedencias(idFuente));
            return lista.ToList();
        }

        //Destinos
        public List<int> FuentesDestinos(int idFuente)
        {
            var lista = CommonBC.Modelo.relacion.Where(r => r.numero_fuente == idFuente && r.id_tipo_relacion == 2).Select(r => r.numero_fuente_relacionada);
            return lista.ToList();
        }

        public List<int> ListaDestinosNoAsociados(int idFuente)
        {
            var lista = ListaCompletaFuente().Except(FuentesDestinos(idFuente));
            return lista.ToList();
        }

        //Minors
        public List<int> FuentesMinors(int idFuente)
        {
            var lista = CommonBC.Modelo.relacion.Where(r => r.numero_fuente == idFuente && r.id_tipo_relacion == 3).Select(r => r.numero_fuente_relacionada);
            return lista.ToList();
        }

        public List<int> ListaMinorsNoAsociadas(int idFuente)
        {
            var lista = ListaCompletaFuente().Except(FuentesMinors(idFuente));
            return lista.ToList();
        }

        public object ListaFuentes()
        {
            var query = (from f in DescripcionFuente_ReadAll()
                         join p in Periodicidad_ReadAll() on f.Periodicidad equals p.Id_Periodicidad
                         join e in Extractor_ReadAll() on f.Tipo_Extractor equals e.Id_Extractor
                         select new
                         {
                             Nº_Fuente = f.Numero_Fuente,
                             Sistema = f.Sistema_Fuente,
                             Nombre_Fuente = f.Nombre,                             
                             Archivo = f.Archivo_Fuente,
                             Contenido = f.Contenido,
                             Cantidad_Registros = f.Cantidad_Registros,
                             Periodicidad = p.Nombre_Periodicidad,
                             Tipo_Extractor = e.Nombre_Extractor
                         }).ToList();
            return query;
        }

        public List<string> ListaSistemas()
        {
            var lista = DescripcionFuente_ReadAll().Select(f => f.Sistema_Fuente).Distinct();
            return lista.ToList();
        }

        public object ListasFuentesPersonalizadas(string nombreSistema)
        {
            var query = (from f in DescripcionFuente_ReadAll()
                         join p in Periodicidad_ReadAll() on f.Periodicidad equals p.Id_Periodicidad
                         join e in Extractor_ReadAll() on f.Tipo_Extractor equals e.Id_Extractor
                         where f.Sistema_Fuente == nombreSistema
                         select new
                         {
                             Nº_Fuente = f.Numero_Fuente,
                             Sistema = f.Sistema_Fuente,
                             Nombre_Fuente = f.Nombre,                             
                             Archivo = f.Archivo_Fuente,
                             Contenido = f.Contenido,
                             Cantidad_Registros = f.Cantidad_Registros,
                             Periodicidad = p.Nombre_Periodicidad,
                             Tipo_Extractor = e.Nombre_Extractor
                         }).ToList();
            return query;
        }

        public object ListaPrecedencias(int idFuente)
        {
            var queryR = (from f in DescripcionFuente_ReadAll()
                          join r in RelacionReadAll() on f.Numero_Fuente equals r.Numero_Fuente_Relacionada
                          select new
                          {
                              Id = r.Numero_Fuente_Relacionada,
                              Sistema = f.Sistema_Fuente,
                              Archivo = f.Archivo_Fuente
                          }).ToList();
            var query = (from f in DescripcionFuente_ReadAll()
                         join r in RelacionReadAll() on f.Numero_Fuente equals r.Numero_Fuente
                         join q in queryR on r.Numero_Fuente_Relacionada equals q.Id
                         select new
                         {
                             Id_Relacionada = r.Numero_Fuente_Relacionada,
                             Id = r.Numero_Fuente,
                             Sistema = f.Sistema_Fuente,
                             Archivo = q.Archivo
                         }).ToList();
            var lista = DescripcionFuente_ReadAll().Select(f => f.Numero_Fuente + " " + f.Archivo_Fuente).Except(query.Where(q => q.Id == idFuente).Select(q => q.Id_Relacionada + " " + q.Archivo)).ToList();
            return lista;
        }

        public object ListaPrecedenciasLB(int idFuente, int tipo)
        {
            var queryR = (from f in DescripcionFuente_ReadAll()
                          join r in RelacionReadAll() on f.Numero_Fuente equals r.Numero_Fuente_Relacionada
                          select new
                          {
                              Id = r.Numero_Fuente_Relacionada,
                              Sistema = f.Sistema_Fuente,
                              Archivo = f.Archivo_Fuente
                          }).ToList();
            var query = (from f in DescripcionFuente_ReadAll()
                         join r in RelacionReadAll() on f.Numero_Fuente equals r.Numero_Fuente
                         join q in queryR on r.Numero_Fuente_Relacionada equals q.Id
                         select new
                         {
                             Id_Relacionada = r.Numero_Fuente_Relacionada,
                             Id = r.Numero_Fuente,
                             Sistema = f.Sistema_Fuente,
                             Archivo = q.Archivo,
                             Tipo = r.Id_Tipo_Relacion
                         }).ToList();
            var lista = query.Where(f => f.Id == idFuente && f.Tipo == tipo).Select(f => f.Id_Relacionada + " " + f.Archivo).Distinct().ToList();
            return lista;
        }
        
        public int IdTipoUsuarioPorNombre(string nombreTipoUsuario)
        {
            int Id = (from t in TipoUsuario_ReadAll()
                      where t.Nombre_Tipo == nombreTipoUsuario
                      select t.Id_Tipo_Usuario).Single();
            return Id;
        }

        public string NombreTipoUsuarioPorId(int idTipousuario)
        {
            string Nombre = (from t in TipoUsuario_ReadAll()
                             where t.Id_Tipo_Usuario == idTipousuario
                             select t.Nombre_Tipo).Single();
            return Nombre;
        }

        // Severidades
        public List<Severidades> Severidades_ReadAll()
        {
            return SeveridadesGenerarListado(CommonBC.Modelo.severidades.ToList());
        }

        private List<Severidades> SeveridadesGenerarListado(List<DALC.severidades> listaDALC)
        {
            List<Severidades> listaBC = new List<Severidades>();
            foreach (DALC.severidades i in listaDALC)
            {
                Severidades per = new Severidades()
                {
                    Id_Severidades = i.id_severidades
                    ,Data = i.data_fuente
                    ,Destination_Table_Name = i.destination_table_name
                    ,Source_Column_Name = i.source_column_name
                    ,Fuente_Destino = i.fuente_destino
                    ,Ref_Table_Name = i.ref_table_name
                    ,Ref_Column_Name = i.ref_column_name
                    ,Business_Rule_Cd = i.business
                    ,Business_Rule_Desc = i.buss_rule_desc
                    ,Id_Quality_Type = i.id_quality_type
                    ,Estado = i.estado
                    ,Numero_Fuente = i.numero_fuente
                };
                listaBC.Add(per);
            }
            return listaBC;
        }

        public object ListarSeveridad(int num_fuente)
        {
            var query = (from f in Severidades_ReadAll()
                         join p in Tipo_Calidad_ReadAll() on f.Id_Quality_Type equals p.Id_Quality_Type
                         where f.Numero_Fuente == num_fuente
                         select new
                         {
                             Nº_Fuente = f.Numero_Fuente
                             ,Id_Severidad = f.Id_Severidades
                             ,Data = f.Data
                             ,Destination_Table_Name = f.Destination_Table_Name
                             ,Source_Column_Name = f.Source_Column_Name
                             ,Fuente_Destino = f.Fuente_Destino
                             ,Ref_Table_Name = f.Ref_Table_Name
                             ,Ref_Column_Name = f.Ref_Column_Name
                             ,Business_Rule_Cd = f.Business_Rule_Cd
                             ,Bussines_Rule_Desc = f.Business_Rule_Desc
                             ,Id_Quality_Type = p.Nombre_Calidad
                             ,Estado = f.Estado
                         }).ToList();
            return query;
        }

        public int IdQualityTypePorNombre(string nombreQualityType)
        {
            int Id = (from p in Tipo_Calidad_ReadAll()
                      where p.Nombre_Calidad == nombreQualityType
                      select p.Id_Quality_Type).Single();
            return Id;
        }

        public string IdQualityTypePorId(int idQualityType)
        {
            string Id = (from p in Tipo_Calidad_ReadAll()
                      where p.Id_Quality_Type == idQualityType
                      select p.Nombre_Calidad).Single();
            return Id;
        }

        //Tipo_Calidad
        public List<Tipo_Calidad> Tipo_Calidad_ReadAll()
        {
            return Tipo_CalidadGenerarListado(CommonBC.Modelo.tipo_calidad.ToList());
        }

        private List<Tipo_Calidad> Tipo_CalidadGenerarListado(List<DALC.tipo_calidad> listaDALC)
        {
            List<Tipo_Calidad> listaBC = new List<Tipo_Calidad>();
            foreach (DALC.tipo_calidad i in listaDALC)
            {
                Tipo_Calidad per = new Tipo_Calidad()
                {
                    Id_Quality_Type = i.id_quality_type
                    ,Nombre_Calidad = i.nombre
                };
                listaBC.Add(per);
            }
            return listaBC;
        }
    }
}
