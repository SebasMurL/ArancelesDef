using lib_dominio.Entidades;
using lib_dominio.Nucleo;
using lib_presentaciones;
using lib_presentaciones.Implementaciones;
using lib_presentaciones.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace asp_presentacion.Pages
{
    public class IndexModel : PageModel
    {
        public bool EstaLogueado = false;
        private Comunicaciones? comunicaciones = null;
        [BindProperty] public string? Email { get; set; }
        [BindProperty] public string? Contrasena { get; set; }
        public async Task<List<Usuarios>> CargarUsuarios()
        {
            try
            {
                var lista = new List<Usuarios>();
                var datos = new Dictionary<string, object>();
                comunicaciones = new Comunicaciones();
                datos = comunicaciones.ConstruirUrl(datos, "Usuarios/Listar");
                var respuesta = await comunicaciones!.Ejecutar(datos);
                if (respuesta.ContainsKey("Error"))
                {
                    throw new Exception(respuesta["Error"].ToString()!);
                }
                lista = JsonConversor.ConvertirAObjeto<List<Usuarios>>(
                    JsonConversor.ConvertirAString(respuesta["Entidades"]));
                return lista;
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
                return null;
            }
        }

        public void OnGet()
        {
            var variable_session = HttpContext.Session.GetString("Usuario");
            if (!String.IsNullOrEmpty(variable_session))
            {
                EstaLogueado = true;
                return;
            }
        }

        public void OnPostBtClean()
        {
            try
            {
                Email = string.Empty;
                Contrasena = string.Empty;
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public void OnPostBtEnter()
        {
            try
            {
                List<Usuarios>? lista = CargarUsuarios().Result;
                if (string.IsNullOrEmpty(Email) &&
                    string.IsNullOrEmpty(Contrasena))
                {
                    OnPostBtClean();
                    return;
                }
                int i = 0;
                while (i<lista.Count)
                {
                    if (lista[i].Usuario == Email &&
                        lista[i].Contraseña == Contrasena)
                    {
                        ViewData["Logged"] = true;
                        HttpContext.Session.SetString("Usuario", Email!);
                        EstaLogueado = true;
                        OnPostBtClean();
                        return;
                    }
                    i++;
                }
                /*if ("admin.123" != Email + "." + Contrasena)
                {
                    OnPostBtClean();
                    return;
                }*/
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public void OnPostBtClose()
        {
            try
            {
                HttpContext.Session.Clear();
                HttpContext.Response.Redirect("/");
                EstaLogueado = false;
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }
    }
}