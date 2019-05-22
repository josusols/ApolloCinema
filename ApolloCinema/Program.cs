using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ApolloCinema
{
    class Program
    {
        //Variables.
        static string User = "";
        static string Contra = "";
        static bool bPrincipal = true;
        static bool bAdministracion = true;
        static int contadorEntradas = 0;

        //Instancias de clases. (Las 4 salas del cine)
        static List<SalaCine> Sala = new List<SalaCine>(4);

        //Mensaje Bienvenida.
        static private void mBienvenida()
        {
            Console.WriteLine("*.*=============*.*");
            Console.WriteLine("   APOLLO CINEMA   ");
            Console.WriteLine("*.*=============*.*");
            Console.WriteLine();
            Console.WriteLine("A: Administrador");
            Console.WriteLine("Cualquier tecla: Cliente");
            Console.WriteLine();
            Console.WriteLine("INGRESE SU ESTATUS");
        }

        //Validación Bienvenida: Admin o Cliente.
        static private bool vBienvenida(string eleccion)
        {
            if (eleccion == "A") //Es administrador.
            {
                return true;
            }
            else if (eleccion == "a") //Es administrador.
            {
                return true;
            }
            return false;
        }

        //Mensaje Administrador.
        static private void mAdmin()
        {
            Console.WriteLine("*.*=============*.*");
            Console.WriteLine("   APOLLO CINEMA   ");
            Console.WriteLine("*.*=============*.*");
            Console.WriteLine();
            Console.WriteLine("Ingrese el nombre de usuario: ");
            User = Console.ReadLine();
            Console.WriteLine("Ingrese la contraseña: ");
            Contra = Console.ReadLine();
        }

        //Validación Administrador: Usuario y Contraseña.
        static private bool vAdmin(string usuario, string contra)
        {
            if (usuario == "admin" && contra == "admin")
            {
                Console.WriteLine();
                Console.WriteLine("¡Bienvenido Administrador!");
                Console.ReadKey();
                Console.Clear();
                return true;
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("¡Datos erroneos!");
                Console.ReadKey();
                Console.Clear();
                return false;
            }
        }

        //Menú Principal.
        static private void M_Principal()
        {
            bPrincipal = true;
            while (bPrincipal)
            {
                mBienvenida();
                if (vBienvenida(Console.ReadLine()))
                {
                    Console.Clear();
                    //Validar Admin.
                    mAdmin();
                    if (vAdmin(User, Contra))
                    {
                        //Exito, Admin.
                        bPrincipal = false;
                        M_Administracion();
                    }
                }
                else
                {
                    //Cliente
                    bPrincipal = false;
                    Compra();
                }
            }
        }

        //------------------------------------------------------------------------------.

        //Mensaje Administración.
        static private void mAdministracion()
        {
            Console.WriteLine("*.*=============*.*");
            Console.WriteLine("   APOLLO CINEMA   ");
            Console.WriteLine("*.*=============*.*");
            Console.WriteLine();
            Console.WriteLine("     .:ADMIN:.");
            Console.WriteLine();
            Console.WriteLine("Cualquier tecla: Menú peliculas");
            Console.WriteLine("M: Menú principal");
            Console.WriteLine();
            Console.WriteLine("INGRESE SU ELECCION");
        }

        //Validaciones Administración.
        static private bool vAdministracion(string eleccion)
        {
            if (eleccion == "M") //Quiere regresar al menú principal.
            {
                return true;
            }
            else if (eleccion == "m") //Quiere regresar al menú principal.
            {
                return true;
            }
            return false;
        }

        //Menú Administración.
        static private void M_Administracion()
        {
            bAdministracion = true;
            while (bAdministracion)
            {
                mAdministracion();
                if (vAdministracion(Console.ReadLine()))
                {
                    Console.Clear();
                    bAdministracion = false;
                    M_Principal();
                }
                else
                {
                    Console.Clear();
                    //Siguiente menu.
                    mPeliculas();
                    if (vPeliculas(Console.ReadLine()))
                    {
                        //Ingresar.
                        Ingreso();
                    }
                    else
                    {
                        //Modificar.
                        Modificar();
                    }

                    Console.Clear();
                }
            }
        }

        //------------------------------------------------------------------------------.

        //Mensaje Peliculas.
        static private void mPeliculas()
        {
            Console.WriteLine("*.*=============*.*");
            Console.WriteLine("   APOLLO CINEMA   ");
            Console.WriteLine("*.*=============*.*");
            Console.WriteLine();
            Console.WriteLine("   .:PELICULAS:.");
            Console.WriteLine();
            Console.WriteLine("I: Ingresar pelicula");
            Console.WriteLine("Cualquier tecla: Modificar pelicula");
            Console.WriteLine();
            Console.WriteLine("INGRESE SU ELECCION");
        }

        //Validaciones Peliculas.
        static private bool vPeliculas(string eleccion)
        {
            if (eleccion == "I") //Quiere ingresar una pelicula.
            {
                return true;
            }
            else if (eleccion == "i") //Quiere ingresar una pelicula.
            {
                return true;
            }
            return false;
        }

        //------------------------------------------------------------------------------.

        //Ingreso de peliculas.
        static private void Ingreso()
        {
            Console.Clear();
            Console.WriteLine("*.*=============*.*");
            Console.WriteLine("   APOLLO CINEMA   ");
            Console.WriteLine("*.*=============*.*");
            Console.WriteLine();
            Console.WriteLine("   .:PELICULAS:.");
            Console.WriteLine();
            Console.WriteLine("Ingrese el número de sala:");
            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine("Ingrese la hora de inicio:");
                    switch (Console.ReadLine())
                    {
                        case "1":
                            if (Sala[0].peliculasSala[0].LlenoAdmin == false)
                            {
                                Sala[0].peliculasSala[0].Sala = "1";
                                Sala[0].peliculasSala[0].Horario = "1";
                                Console.WriteLine("Ingrese el nombre de la pelicula:");
                                Sala[0].peliculasSala[0].Nombre = Console.ReadLine();
                                Console.WriteLine("Ingrese el precio:");
                                try
                                {
                                    Sala[0].peliculasSala[0].PrecioTicket = Convert.ToUInt32(Console.ReadLine());
                                    Sala[0].peliculasSala[0].LlenoAdmin = true;
                                }
                                catch
                                {
                                    Console.WriteLine("El precio del ticket debe ser un entero positivo, intentelo de nuevo.");
                                    Console.ReadKey();
                                    Ingreso();
                                }
                                break;
                            }
                            else
                            {
                                Console.WriteLine("La pelicula en el horario deseado y sala deseada ya esta establecida.\r\nPara cambiar entre al menú modificar.");
                                Console.ReadKey();
                                break;
                            }
                        case "3":
                            if (Sala[0].peliculasSala[1].LlenoAdmin == false)
                            {
                                Sala[0].peliculasSala[1].Sala = "1";
                                Sala[0].peliculasSala[1].Horario = "3";
                                Console.WriteLine("Ingrese el nombre de la pelicula:");
                                Sala[0].peliculasSala[1].Nombre = Console.ReadLine();
                                Console.WriteLine("Ingrese el precio:");
                                try
                                {
                                    Sala[0].peliculasSala[1].PrecioTicket = Convert.ToUInt32(Console.ReadLine());
                                    Sala[0].peliculasSala[1].LlenoAdmin = true;
                                }
                                catch
                                {
                                    Console.WriteLine("El precio del ticket debe ser un entero positivo, intentelo de nuevo.");
                                    Console.ReadKey();
                                    Ingreso();
                                }
                                break;
                            }
                            else
                            {
                                Console.WriteLine("La pelicula en el horario deseado y sala deseada ya esta establecida.\r\nPara cambiar entre al menú modificar.");
                                Console.ReadKey();
                                break;
                            }

                        case "5":
                            if (Sala[0].peliculasSala[2].LlenoAdmin == false)
                            {
                                Sala[0].peliculasSala[2].Sala = "1";
                                Sala[0].peliculasSala[2].Horario = "5";
                                Console.WriteLine("Ingrese el nombre de la pelicula:");
                                Sala[0].peliculasSala[2].Nombre = Console.ReadLine();
                                Console.WriteLine("Ingrese el precio:");
                                try
                                {
                                    Sala[0].peliculasSala[2].PrecioTicket = Convert.ToUInt32(Console.ReadLine());
                                    Sala[0].peliculasSala[2].LlenoAdmin = true;
                                }
                                catch
                                {
                                    Console.WriteLine("El precio del ticket debe ser un entero positivo, intentelo de nuevo.");
                                    Console.ReadKey();
                                    Ingreso();
                                }
                                break;
                            }
                            else
                            {
                                Console.WriteLine("La pelicula en el horario deseado y sala deseada ya esta establecida.\r\nPara cambiar entre al menú modificar.");
                                Console.ReadKey();
                                break;
                            }

                        case "7":
                            if (Sala[0].peliculasSala[3].LlenoAdmin == false)
                            {
                                Sala[0].peliculasSala[3].Sala = "1";
                                Sala[0].peliculasSala[3].Horario = "7";
                                Console.WriteLine("Ingrese el nombre de la pelicula:");
                                Sala[0].peliculasSala[3].Nombre = Console.ReadLine();
                                Console.WriteLine("Ingrese el precio:");
                                try
                                {
                                    Sala[0].peliculasSala[3].PrecioTicket = Convert.ToUInt32(Console.ReadLine());
                                    Sala[0].peliculasSala[3].LlenoAdmin = true;
                                }
                                catch
                                {
                                    Console.WriteLine("El precio del ticket debe ser un entero positivo, intentelo de nuevo.");
                                    Console.ReadKey();
                                    Ingreso();
                                }
                                break;
                            }
                            else
                            {
                                Console.WriteLine("La pelicula en el horario deseado y sala deseada ya esta establecida.\r\nPara cambiar entre al menú modificar.");
                                Console.ReadKey();
                                break;
                            }

                        case "9":
                            if (Sala[0].peliculasSala[4].LlenoAdmin == false)
                            {
                                Sala[0].peliculasSala[4].Sala = "1";
                                Sala[0].peliculasSala[4].Horario = "9";
                                Console.WriteLine("Ingrese el nombre de la pelicula:");
                                Sala[0].peliculasSala[4].Nombre = Console.ReadLine();
                                Console.WriteLine("Ingrese el precio:");
                                try
                                {
                                    Sala[0].peliculasSala[4].PrecioTicket = Convert.ToUInt32(Console.ReadLine());
                                    Sala[0].peliculasSala[4].LlenoAdmin = true;
                                }
                                catch
                                {
                                    Console.WriteLine("El precio del ticket debe ser un entero positivo, intentelo de nuevo.");
                                    Console.ReadKey();
                                    Ingreso();
                                }
                                break;
                            }
                            else
                            {
                                Console.WriteLine("La pelicula en el horario deseado y sala deseada ya esta establecida.\r\nPara cambiar entre al menú modificar.");
                                Console.ReadKey();
                                break;
                            }

                        default:
                            Console.WriteLine("Horario no existe, intentelo de nuevo.");
                            Console.ReadKey();
                            Ingreso();
                            break;
                    }
                    break;

                case "2":
                    Console.WriteLine("Ingrese la hora de inicio:");
                    switch (Console.ReadLine())
                    {
                        case "1":
                            if (Sala[1].peliculasSala[0].LlenoAdmin == false)
                            {
                                Sala[1].peliculasSala[0].Sala = "2";
                                Sala[1].peliculasSala[0].Horario = "1";
                                Console.WriteLine("Ingrese el nombre de la pelicula:");
                                Sala[1].peliculasSala[0].Nombre = Console.ReadLine();
                                Console.WriteLine("Ingrese el precio:");
                                try
                                {
                                    Sala[1].peliculasSala[0].PrecioTicket = Convert.ToUInt32(Console.ReadLine());
                                    Sala[1].peliculasSala[0].LlenoAdmin = true;
                                }
                                catch
                                {
                                    Console.WriteLine("El precio del ticket debe ser un entero positivo, intentelo de nuevo.");
                                    Console.ReadKey();
                                    Ingreso();
                                }
                                break;
                            }
                            else
                            {
                                Console.WriteLine("La pelicula en el horario deseado y sala deseada ya esta establecida.\r\nPara cambiar entre al menú modificar.");
                                Console.ReadKey();
                                break;
                            }

                        case "3":
                            if (Sala[1].peliculasSala[1].LlenoAdmin == false)
                            {
                                Sala[1].peliculasSala[1].Sala = "2";
                                Sala[1].peliculasSala[1].Horario = "3";
                                Console.WriteLine("Ingrese el nombre de la pelicula:");
                                Sala[1].peliculasSala[1].Nombre = Console.ReadLine();
                                Console.WriteLine("Ingrese el precio:");
                                try
                                {
                                    Sala[1].peliculasSala[1].PrecioTicket = Convert.ToUInt32(Console.ReadLine());
                                    Sala[1].peliculasSala[1].LlenoAdmin = true;
                                }
                                catch
                                {
                                    Console.WriteLine("El precio del ticket debe ser un entero positivo, intentelo de nuevo.");
                                    Console.ReadKey();
                                    Ingreso();
                                }
                                break;
                            }
                            else
                            {
                                Console.WriteLine("La pelicula en el horario deseado y sala deseada ya esta establecida.\r\nPara cambiar entre al menú modificar.");
                                Console.ReadKey();
                                break;
                            }

                        case "5":
                            if (Sala[1].peliculasSala[2].LlenoAdmin == false)
                            {
                                Sala[1].peliculasSala[2].Sala = "2";
                                Sala[1].peliculasSala[2].Horario = "5";
                                Console.WriteLine("Ingrese el nombre de la pelicula:");
                                Sala[1].peliculasSala[2].Nombre = Console.ReadLine();
                                Console.WriteLine("Ingrese el precio:");
                                try
                                {
                                    Sala[1].peliculasSala[2].PrecioTicket = Convert.ToUInt32(Console.ReadLine());
                                    Sala[1].peliculasSala[2].LlenoAdmin = true;
                                }
                                catch
                                {
                                    Console.WriteLine("El precio del ticket debe ser un entero positivo, intentelo de nuevo.");
                                    Console.ReadKey();
                                    Ingreso();
                                }
                                break;
                            }
                            else
                            {
                                Console.WriteLine("La pelicula en el horario deseado y sala deseada ya esta establecida.\r\nPara cambiar entre al menú modificar.");
                                Console.ReadKey();
                                break;
                            }

                        case "7":
                            if (Sala[1].peliculasSala[3].LlenoAdmin == false)
                            {
                                Sala[1].peliculasSala[3].Sala = "2";
                                Sala[1].peliculasSala[3].Horario = "7";
                                Console.WriteLine("Ingrese el nombre de la pelicula:");
                                Sala[1].peliculasSala[3].Nombre = Console.ReadLine();
                                Console.WriteLine("Ingrese el precio:");
                                try
                                {
                                    Sala[1].peliculasSala[3].PrecioTicket = Convert.ToUInt32(Console.ReadLine());
                                    Sala[1].peliculasSala[3].LlenoAdmin = true;
                                }
                                catch
                                {
                                    Console.WriteLine("El precio del ticket debe ser un entero positivo, intentelo de nuevo.");
                                    Console.ReadKey();
                                    Ingreso();
                                }
                                break;
                            }
                            else
                            {
                                Console.WriteLine("La pelicula en el horario deseado y sala deseada ya esta establecida.\r\nPara cambiar entre al menú modificar.");
                                Console.ReadKey();
                                break;
                            }

                        case "9":
                            if (Sala[1].peliculasSala[4].LlenoAdmin == false)
                            {
                                Sala[1].peliculasSala[4].Sala = "2";
                                Sala[1].peliculasSala[4].Horario = "9";
                                Console.WriteLine("Ingrese el nombre de la pelicula:");
                                Sala[1].peliculasSala[4].Nombre = Console.ReadLine();
                                Console.WriteLine("Ingrese el precio:");
                                try
                                {
                                    Sala[1].peliculasSala[4].PrecioTicket = Convert.ToUInt32(Console.ReadLine());
                                    Sala[1].peliculasSala[4].LlenoAdmin = true;
                                }
                                catch
                                {
                                    Console.WriteLine("El precio del ticket debe ser un entero positivo, intentelo de nuevo.");
                                    Console.ReadKey();
                                    Ingreso();
                                }
                                break;
                            }
                            else
                            {
                                Console.WriteLine("La pelicula en el horario deseado y sala deseada ya esta establecida.\r\nPara cambiar entre al menú modificar.");
                                Console.ReadKey();
                                break;
                            }

                        default:
                            Console.WriteLine("Horario no existe, intentelo de nuevo.");
                            Console.ReadKey();
                            Ingreso();
                            break;
                    }
                    break;

                case "3":
                    Console.WriteLine("Ingrese la hora de inicio:");
                    switch (Console.ReadLine())
                    {
                        case "1":
                            if (Sala[2].peliculasSala[0].LlenoAdmin == false)
                            {
                                Sala[2].peliculasSala[0].Sala = "3";
                                Sala[2].peliculasSala[0].Horario = "1";
                                Console.WriteLine("Ingrese el nombre de la pelicula:");
                                Sala[2].peliculasSala[0].Nombre = Console.ReadLine();
                                Console.WriteLine("Ingrese el precio:");
                                try
                                {
                                    Sala[2].peliculasSala[0].PrecioTicket = Convert.ToUInt32(Console.ReadLine());
                                    Sala[2].peliculasSala[0].LlenoAdmin = true;
                                }
                                catch
                                {
                                    Console.WriteLine("El precio del ticket debe ser un entero positivo, intentelo de nuevo.");
                                    Console.ReadKey();
                                    Ingreso();
                                }
                                break;
                            }
                            else
                            {
                                Console.WriteLine("La pelicula en el horario deseado y sala deseada ya esta establecida.\r\nPara cambiar entre al menú modificar.");
                                Console.ReadKey();
                                break;
                            }

                        case "3":
                            if (Sala[2].peliculasSala[1].LlenoAdmin == false)
                            {
                                Sala[2].peliculasSala[1].Sala = "3";
                                Sala[2].peliculasSala[1].Horario = "3";
                                Console.WriteLine("Ingrese el nombre de la pelicula:");
                                Sala[2].peliculasSala[1].Nombre = Console.ReadLine();
                                Console.WriteLine("Ingrese el precio:");
                                try
                                {
                                    Sala[2].peliculasSala[1].PrecioTicket = Convert.ToUInt32(Console.ReadLine());
                                    Sala[2].peliculasSala[1].LlenoAdmin = true;
                                }
                                catch
                                {
                                    Console.WriteLine("El precio del ticket debe ser un entero positivo, intentelo de nuevo.");
                                    Console.ReadKey();
                                    Ingreso();
                                }
                                break;
                            }
                            else
                            {
                                Console.WriteLine("La pelicula en el horario deseado y sala deseada ya esta establecida.\r\nPara cambiar entre al menú modificar.");
                                Console.ReadKey();
                                break;
                            }

                        case "5":
                            if (Sala[3].peliculasSala[2].LlenoAdmin == false)
                            {
                                Sala[2].peliculasSala[2].Sala = "3";
                                Sala[2].peliculasSala[2].Horario = "5";
                                Console.WriteLine("Ingrese el nombre de la pelicula:");
                                Sala[2].peliculasSala[2].Nombre = Console.ReadLine();
                                Console.WriteLine("Ingrese el precio:");
                                try
                                {
                                    Sala[2].peliculasSala[2].PrecioTicket = Convert.ToUInt32(Console.ReadLine());
                                    Sala[2].peliculasSala[2].LlenoAdmin = true;
                                }
                                catch
                                {
                                    Console.WriteLine("El precio del ticket debe ser un entero positivo, intentelo de nuevo.");
                                    Console.ReadKey();
                                    Ingreso();
                                }
                                break;
                            }
                            else
                            {
                                Console.WriteLine("La pelicula en el horario deseado y sala deseada ya esta establecida.\r\nPara cambiar entre al menú modificar.");
                                Console.ReadKey();
                                break;
                            }

                        case "7":
                            if (Sala[2].peliculasSala[3].LlenoAdmin == false)
                            {
                                Sala[2].peliculasSala[3].Sala = "3";
                                Sala[2].peliculasSala[3].Horario = "7";
                                Console.WriteLine("Ingrese el nombre de la pelicula:");
                                Sala[2].peliculasSala[3].Nombre = Console.ReadLine();
                                Console.WriteLine("Ingrese el precio:");
                                try
                                {
                                    Sala[2].peliculasSala[3].PrecioTicket = Convert.ToUInt32(Console.ReadLine());
                                    Sala[2].peliculasSala[3].LlenoAdmin = true;
                                }
                                catch
                                {
                                    Console.WriteLine("El precio del ticket debe ser un entero positivo, intentelo de nuevo.");
                                    Console.ReadKey();
                                    Ingreso();
                                }
                                break;
                            }
                            else
                            {
                                Console.WriteLine("La pelicula en el horario deseado y sala deseada ya esta establecida.\r\nPara cambiar entre al menú modificar.");
                                Console.ReadKey();
                                break;
                            }

                        case "9":
                            if (Sala[2].peliculasSala[4].LlenoAdmin == false)
                            {
                                Sala[2].peliculasSala[4].Sala = "3";
                                Sala[2].peliculasSala[4].Horario = "9";
                                Console.WriteLine("Ingrese el nombre de la pelicula:");
                                Sala[2].peliculasSala[4].Nombre = Console.ReadLine();
                                Console.WriteLine("Ingrese el precio:");
                                try
                                {
                                    Sala[2].peliculasSala[4].PrecioTicket = Convert.ToUInt32(Console.ReadLine());
                                    Sala[2].peliculasSala[4].LlenoAdmin = true;
                                }
                                catch
                                {
                                    Console.WriteLine("El precio del ticket debe ser un entero positivo, intentelo de nuevo.");
                                    Console.ReadKey();
                                    Ingreso();
                                }
                                break;
                            }
                            else
                            {
                                Console.WriteLine("La pelicula en el horario deseado y sala deseada ya esta establecida.\r\nPara cambiar entre al menú modificar.");
                                Console.ReadKey();
                                break;
                            }

                        default:
                            Console.WriteLine("Horario no existe, intentelo de nuevo.");
                            Console.ReadKey();
                            Ingreso();
                            break;
                    }
                    break;

                case "4":
                    Console.WriteLine("Ingrese la hora de inicio:");
                    switch (Console.ReadLine())
                    {
                        case "1":
                            if (Sala[3].peliculasSala[0].LlenoAdmin == false)
                            {
                                Sala[3].peliculasSala[0].Sala = "4";
                                Sala[3].peliculasSala[0].Horario = "1";
                                Console.WriteLine("Ingrese el nombre de la pelicula:");
                                Sala[3].peliculasSala[0].Nombre = Console.ReadLine();
                                Console.WriteLine("Ingrese el precio:");
                                try
                                {
                                    Sala[3].peliculasSala[0].PrecioTicket = Convert.ToUInt32(Console.ReadLine());
                                    Sala[3].peliculasSala[0].LlenoAdmin = true;
                                }
                                catch
                                {
                                    Console.WriteLine("El precio del ticket debe ser un entero positivo, intentelo de nuevo.");
                                    Console.ReadKey();
                                    Ingreso();
                                }
                                break;
                            }
                            else
                            {
                                Console.WriteLine("La pelicula en el horario deseado y sala deseada ya esta establecida.\r\nPara cambiar entre al menú modificar.");
                                Console.ReadKey();
                                break;
                            }

                        case "3":
                            if (Sala[3].peliculasSala[1].LlenoAdmin == false)
                            {
                                Sala[3].peliculasSala[1].Sala = "4";
                                Sala[3].peliculasSala[1].Horario = "3";
                                Console.WriteLine("Ingrese el nombre de la pelicula:");
                                Sala[3].peliculasSala[1].Nombre = Console.ReadLine();
                                Console.WriteLine("Ingrese el precio:");
                                try
                                {
                                    Sala[3].peliculasSala[1].PrecioTicket = Convert.ToUInt32(Console.ReadLine());
                                    Sala[3].peliculasSala[1].LlenoAdmin = true;
                                }
                                catch
                                {
                                    Console.WriteLine("El precio del ticket debe ser un entero positivo, intentelo de nuevo.");
                                    Console.ReadKey();
                                    Ingreso();
                                }
                                break;
                            }
                            else
                            {
                                Console.WriteLine("La pelicula en el horario deseado y sala deseada ya esta establecida.\r\nPara cambiar entre al menú modificar.");
                                Console.ReadKey();
                                break;
                            }

                        case "5":
                            if (Sala[3].peliculasSala[2].LlenoAdmin == false)
                            {
                                Sala[3].peliculasSala[2].Sala = "4";
                                Sala[3].peliculasSala[2].Horario = "5";
                                Console.WriteLine("Ingrese el nombre de la pelicula:");
                                Sala[3].peliculasSala[2].Nombre = Console.ReadLine();
                                Console.WriteLine("Ingrese el precio:");
                                try
                                {
                                    Sala[3].peliculasSala[2].PrecioTicket = Convert.ToUInt32(Console.ReadLine());
                                    Sala[3].peliculasSala[2].LlenoAdmin = true;
                                }
                                catch
                                {
                                    Console.WriteLine("El precio del ticket debe ser un entero positivo, intentelo de nuevo.");
                                    Console.ReadKey();
                                    Ingreso();
                                }
                                break;
                            }
                            else
                            {
                                Console.WriteLine("La pelicula en el horario deseado y sala deseada ya esta establecida.\r\nPara cambiar entre al menú modificar.");
                                Console.ReadKey();
                                break;
                            }

                        case "7":
                            if (Sala[3].peliculasSala[3].LlenoAdmin == false)
                            {
                                Sala[3].peliculasSala[3].Sala = "4";
                                Sala[3].peliculasSala[3].Horario = "7";
                                Console.WriteLine("Ingrese el nombre de la pelicula:");
                                Sala[3].peliculasSala[3].Nombre = Console.ReadLine();
                                Console.WriteLine("Ingrese el precio:");
                                try
                                {
                                    Sala[3].peliculasSala[3].PrecioTicket = Convert.ToUInt32(Console.ReadLine());
                                    Sala[3].peliculasSala[3].LlenoAdmin = true;
                                }
                                catch
                                {
                                    Console.WriteLine("El precio del ticket debe ser un entero positivo, intentelo de nuevo.");
                                    Console.ReadKey();
                                    Ingreso();
                                }
                                break;
                            }
                            else
                            {
                                Console.WriteLine("La pelicula en el horario deseado y sala deseada ya esta establecida.\r\nPara cambiar entre al menú modificar.");
                                Console.ReadKey();
                                break;
                            }

                        case "9":
                            if (Sala[3].peliculasSala[4].LlenoAdmin == false)
                            {
                                Sala[3].peliculasSala[4].Sala = "4";
                                Sala[3].peliculasSala[4].Horario = "9";
                                Console.WriteLine("Ingrese el nombre de la pelicula:");
                                Sala[3].peliculasSala[4].Nombre = Console.ReadLine();
                                Console.WriteLine("Ingrese el precio:");
                                try
                                {
                                    Sala[3].peliculasSala[4].PrecioTicket = Convert.ToUInt32(Console.ReadLine());
                                    Sala[3].peliculasSala[4].LlenoAdmin = true;
                                }
                                catch
                                {
                                    Console.WriteLine("El precio del ticket debe ser un entero positivo, intentelo de nuevo.");
                                    Console.ReadKey();
                                    Ingreso();
                                }
                                break;
                            }
                            else
                            {
                                Console.WriteLine("La pelicula en el horario deseado y sala deseada ya esta establecida.\r\nPara cambiar entre al menú modificar.");
                                Console.ReadKey();
                                break;
                            }

                        default:
                            Console.WriteLine("Horario no existe, intentelo de nuevo.");
                            Console.ReadKey();
                            Ingreso();
                            break;
                    }
                    break;

                default:
                    Console.WriteLine("Sala no existe, intente de nuevo");
                    Console.ReadKey();
                    Ingreso();
                    break;
            }
        }

        //Modificacion de peliculas.
        static private void Modificar()
        {
            Console.Clear();
            Console.WriteLine("*.*=============*.*");
            Console.WriteLine("   APOLLO CINEMA   ");
            Console.WriteLine("*.*=============*.*");
            Console.WriteLine();
            Console.WriteLine("   .:PELICULAS:.");
            Console.WriteLine("   ::MODIFICAR::");
            Console.WriteLine();
            Console.WriteLine("Ingrese el número de sala:");
            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine("Ingrese la hora de inicio:");
                    switch (Console.ReadLine())
                    {
                        case "1":
                            if (Sala[0].peliculasSala[0].LlenoAdmin == true)
                            {
                                Console.WriteLine();
                                Console.WriteLine("Nombre actual de la pelicula:");
                                Console.WriteLine(Sala[0].peliculasSala[0].Nombre);
                                Console.WriteLine("Precio actual de la pelicula:");
                                Console.WriteLine(Sala[0].peliculasSala[0].PrecioTicket.ToString());
                                Console.WriteLine();
                                Console.WriteLine("Ingrese el nuevo nombre de la pelicula:");
                                Sala[0].peliculasSala[0].Nombre = Console.ReadLine();
                                Console.WriteLine("Ingrese el nuevo precio:");
                                try
                                {
                                    Sala[0].peliculasSala[0].PrecioTicket = Convert.ToUInt32(Console.ReadLine());
                                }
                                catch
                                {
                                    Console.WriteLine("El precio del ticket debe ser un entero positivo, intentelo de nuevo.");
                                    Console.ReadKey();
                                    Modificar();
                                }
                                break;
                            }
                            else
                            {
                                Console.WriteLine("La pelicula en el horario deseado y sala deseada aun no ha sido ingresada.\r\nPara agregar entre al menú ingresar.");
                                Console.ReadKey();
                                break;
                            }

                        case "3":
                            if (Sala[0].peliculasSala[1].LlenoAdmin == true)
                            {
                                Console.WriteLine();
                                Console.WriteLine("Nombre actual de la pelicula:");
                                Console.WriteLine(Sala[0].peliculasSala[1].Nombre);
                                Console.WriteLine("Precio actual de la pelicula:");
                                Console.WriteLine(Sala[0].peliculasSala[1].PrecioTicket.ToString());
                                Console.WriteLine();
                                Console.WriteLine("Ingrese el nuevo nombre de la pelicula:");
                                Sala[0].peliculasSala[1].Nombre = Console.ReadLine();
                                Console.WriteLine("Ingrese el nuevo precio:");
                                try
                                {
                                    Sala[0].peliculasSala[1].PrecioTicket = Convert.ToUInt32(Console.ReadLine());
                                }
                                catch
                                {
                                    Console.WriteLine("El precio del ticket debe ser un entero positivo, intentelo de nuevo.");
                                    Console.ReadKey();
                                    Modificar();
                                }
                                break;
                            }
                            else
                            {
                                Console.WriteLine("La pelicula en el horario deseado y sala deseada aun no ha sido ingresada.\r\nPara agregar entre al menú ingresar.");
                                Console.ReadKey();
                                break;
                            }

                        case "5":
                            if (Sala[0].peliculasSala[2].LlenoAdmin == true)
                            {
                                Console.WriteLine();
                                Console.WriteLine("Nombre actual de la pelicula:");
                                Console.WriteLine(Sala[0].peliculasSala[2].Nombre);
                                Console.WriteLine("Precio actual de la pelicula:");
                                Console.WriteLine(Sala[0].peliculasSala[2].PrecioTicket.ToString());
                                Console.WriteLine();
                                Console.WriteLine("Ingrese el nuevo nombre de la pelicula:");
                                Sala[0].peliculasSala[2].Nombre = Console.ReadLine();
                                Console.WriteLine("Ingrese el nuevo precio:");
                                try
                                {
                                    Sala[0].peliculasSala[2].PrecioTicket = Convert.ToUInt32(Console.ReadLine());
                                }
                                catch
                                {
                                    Console.WriteLine("El precio del ticket debe ser un entero positivo, intentelo de nuevo.");
                                    Console.ReadKey();
                                    Modificar();
                                }
                                break;
                            }
                            else
                            {
                                Console.WriteLine("La pelicula en el horario deseado y sala deseada aun no ha sido ingresada.\r\nPara agregar entre al menú ingresar.");
                                Console.ReadKey();
                                break;
                            }

                        case "7":
                            if (Sala[0].peliculasSala[3].LlenoAdmin == true)
                            {
                                Console.WriteLine();
                                Console.WriteLine("Nombre actual de la pelicula:");
                                Console.WriteLine(Sala[0].peliculasSala[3].Nombre);
                                Console.WriteLine("Precio actual de la pelicula:");
                                Console.WriteLine(Sala[0].peliculasSala[3].PrecioTicket.ToString());
                                Console.WriteLine();
                                Console.WriteLine("Ingrese el nuevo nombre de la pelicula:");
                                Sala[0].peliculasSala[3].Nombre = Console.ReadLine();
                                Console.WriteLine("Ingrese el nuevo precio:");
                                try
                                {
                                    Sala[0].peliculasSala[3].PrecioTicket = Convert.ToUInt32(Console.ReadLine());
                                }
                                catch
                                {
                                    Console.WriteLine("El precio del ticket debe ser un entero positivo, intentelo de nuevo.");
                                    Console.ReadKey();
                                    Modificar();
                                }
                                break;
                            }
                            else
                            {
                                Console.WriteLine("La pelicula en el horario deseado y sala deseada aun no ha sido ingresada.\r\nPara agregar entre al menú ingresar.");
                                Console.ReadKey();
                                break;
                            }

                        case "9":
                            if (Sala[0].peliculasSala[4].LlenoAdmin == true)
                            {
                                Console.WriteLine();
                                Console.WriteLine("Nombre actual de la pelicula:");
                                Console.WriteLine(Sala[0].peliculasSala[4].Nombre);
                                Console.WriteLine("Precio actual de la pelicula:");
                                Console.WriteLine(Sala[0].peliculasSala[4].PrecioTicket.ToString());
                                Console.WriteLine();
                                Console.WriteLine("Ingrese el nuevo nombre de la pelicula:");
                                Sala[0].peliculasSala[4].Nombre = Console.ReadLine();
                                Console.WriteLine("Ingrese el nuevo precio:");
                                try
                                {
                                    Sala[0].peliculasSala[4].PrecioTicket = Convert.ToUInt32(Console.ReadLine());
                                }
                                catch
                                {
                                    Console.WriteLine("El precio del ticket debe ser un entero positivo, intentelo de nuevo.");
                                    Console.ReadKey();
                                    Modificar();
                                }
                                break;
                            }
                            else
                            {
                                Console.WriteLine("La pelicula en el horario deseado y sala deseada aun no ha sido ingresada.\r\nPara agregar entre al menú ingresar.");
                                Console.ReadKey();
                                break;
                            }

                        default:
                            Console.WriteLine("Horario no existe, intentelo de nuevo.");
                            Console.ReadKey();
                            Modificar();
                            break;
                    }
                    break;

                case "2":
                    Console.WriteLine("Ingrese la hora de inicio:");
                    switch (Console.ReadLine())
                    {
                        case "1":
                            if (Sala[1].peliculasSala[0].LlenoAdmin == true)
                            {
                                Console.WriteLine();
                                Console.WriteLine("Nombre actual de la pelicula:");
                                Console.WriteLine(Sala[1].peliculasSala[0].Nombre);
                                Console.WriteLine("Precio actual de la pelicula:");
                                Console.WriteLine(Sala[1].peliculasSala[0].PrecioTicket.ToString());
                                Console.WriteLine();
                                Console.WriteLine("Ingrese el nuevo nombre de la pelicula:");
                                Sala[1].peliculasSala[0].Nombre = Console.ReadLine();
                                Console.WriteLine("Ingrese el nuevo precio:");
                                try
                                {
                                    Sala[1].peliculasSala[0].PrecioTicket = Convert.ToUInt32(Console.ReadLine());
                                }
                                catch
                                {
                                    Console.WriteLine("El precio del ticket debe ser un entero positivo, intentelo de nuevo.");
                                    Console.ReadKey();
                                    Modificar();
                                }
                                break;
                            }
                            else
                            {
                                Console.WriteLine("La pelicula en el horario deseado y sala deseada aun no ha sido ingresada.\r\nPara agregar entre al menú ingresar.");
                                Console.ReadKey();
                                break;
                            }

                        case "3":
                            if (Sala[1].peliculasSala[1].LlenoAdmin == true)
                            {
                                Console.WriteLine();
                                Console.WriteLine("Nombre actual de la pelicula:");
                                Console.WriteLine(Sala[1].peliculasSala[1].Nombre);
                                Console.WriteLine("Precio actual de la pelicula:");
                                Console.WriteLine(Sala[1].peliculasSala[1].PrecioTicket.ToString());
                                Console.WriteLine();
                                Console.WriteLine("Ingrese el nuevo nombre de la pelicula:");
                                Sala[1].peliculasSala[1].Nombre = Console.ReadLine();
                                Console.WriteLine("Ingrese el nuevo precio:");
                                try
                                {
                                    Sala[1].peliculasSala[1].PrecioTicket = Convert.ToUInt32(Console.ReadLine());
                                }
                                catch
                                {
                                    Console.WriteLine("El precio del ticket debe ser un entero positivo, intentelo de nuevo.");
                                    Console.ReadKey();
                                    Modificar();
                                }
                                break;
                            }
                            else
                            {
                                Console.WriteLine("La pelicula en el horario deseado y sala deseada aun no ha sido ingresada.\r\nPara agregar entre al menú ingresar.");
                                Console.ReadKey();
                                break;
                            }

                        case "5":
                            if (Sala[1].peliculasSala[2].LlenoAdmin == true)
                            {
                                Console.WriteLine();
                                Console.WriteLine("Nombre actual de la pelicula:");
                                Console.WriteLine(Sala[1].peliculasSala[2].Nombre);
                                Console.WriteLine("Precio actual de la pelicula:");
                                Console.WriteLine(Sala[1].peliculasSala[2].PrecioTicket.ToString());
                                Console.WriteLine();
                                Console.WriteLine("Ingrese el nuevo nombre de la pelicula:");
                                Sala[1].peliculasSala[2].Nombre = Console.ReadLine();
                                Console.WriteLine("Ingrese el nuevo precio:");
                                try
                                {
                                    Sala[1].peliculasSala[2].PrecioTicket = Convert.ToUInt32(Console.ReadLine());
                                }
                                catch
                                {
                                    Console.WriteLine("El precio del ticket debe ser un entero positivo, intentelo de nuevo.");
                                    Console.ReadKey();
                                    Modificar();
                                }
                                break;
                            }
                            else
                            {
                                Console.WriteLine("La pelicula en el horario deseado y sala deseada aun no ha sido ingresada.\r\nPara agregar entre al menú ingresar.");
                                Console.ReadKey();
                                break;
                            }

                        case "7":
                            if (Sala[1].peliculasSala[3].LlenoAdmin == true)
                            {
                                Console.WriteLine();
                                Console.WriteLine("Nombre actual de la pelicula:");
                                Console.WriteLine(Sala[1].peliculasSala[3].Nombre);
                                Console.WriteLine("Precio actual de la pelicula:");
                                Console.WriteLine(Sala[1].peliculasSala[3].PrecioTicket.ToString());
                                Console.WriteLine();
                                Console.WriteLine("Ingrese el nuevo nombre de la pelicula:");
                                Sala[1].peliculasSala[3].Nombre = Console.ReadLine();
                                Console.WriteLine("Ingrese el nuevo precio:");
                                try
                                {
                                    Sala[1].peliculasSala[3].PrecioTicket = Convert.ToUInt32(Console.ReadLine());
                                }
                                catch
                                {
                                    Console.WriteLine("El precio del ticket debe ser un entero positivo, intentelo de nuevo.");
                                    Console.ReadKey();
                                    Modificar();
                                }
                                break;
                            }
                            else
                            {
                                Console.WriteLine("La pelicula en el horario deseado y sala deseada aun no ha sido ingresada.\r\nPara agregar entre al menú ingresar.");
                                Console.ReadKey();
                                break;
                            }

                        case "9":
                            if (Sala[1].peliculasSala[4].LlenoAdmin == true)
                            {
                                Console.WriteLine();
                                Console.WriteLine("Nombre actual de la pelicula:");
                                Console.WriteLine(Sala[1].peliculasSala[4].Nombre);
                                Console.WriteLine("Precio actual de la pelicula:");
                                Console.WriteLine(Sala[1].peliculasSala[4].PrecioTicket.ToString());
                                Console.WriteLine();
                                Console.WriteLine("Ingrese el nuevo nombre de la pelicula:");
                                Sala[1].peliculasSala[4].Nombre = Console.ReadLine();
                                Console.WriteLine("Ingrese el nuevo precio:");
                                try
                                {
                                    Sala[1].peliculasSala[4].PrecioTicket = Convert.ToUInt32(Console.ReadLine());
                                }
                                catch
                                {
                                    Console.WriteLine("El precio del ticket debe ser un entero positivo, intentelo de nuevo.");
                                    Console.ReadKey();
                                    Modificar();
                                }
                                break;
                            }
                            else
                            {
                                Console.WriteLine("La pelicula en el horario deseado y sala deseada aun no ha sido ingresada.\r\nPara agregar entre al menú ingresar.");
                                Console.ReadKey();
                                break;
                            }

                        default:
                            Console.WriteLine("Horario no existe, intentelo de nuevo.");
                            Console.ReadKey();
                            Modificar();
                            break;
                    }
                    break;

                case "3":
                    Console.WriteLine("Ingrese la hora de inicio:");
                    switch (Console.ReadLine())
                    {
                        case "1":
                            if (Sala[2].peliculasSala[0].LlenoAdmin == true)
                            {
                                Console.WriteLine();
                                Console.WriteLine("Nombre actual de la pelicula:");
                                Console.WriteLine(Sala[2].peliculasSala[0].Nombre);
                                Console.WriteLine("Precio actual de la pelicula:");
                                Console.WriteLine(Sala[2].peliculasSala[0].PrecioTicket.ToString());
                                Console.WriteLine();
                                Console.WriteLine("Ingrese el nuevo nombre de la pelicula:");
                                Sala[2].peliculasSala[0].Nombre = Console.ReadLine();
                                Console.WriteLine("Ingrese el nuevo precio:");
                                try
                                {
                                    Sala[2].peliculasSala[0].PrecioTicket = Convert.ToUInt32(Console.ReadLine());
                                }
                                catch
                                {
                                    Console.WriteLine("El precio del ticket debe ser un entero positivo, intentelo de nuevo.");
                                    Console.ReadKey();
                                    Modificar();
                                }
                                break;
                            }
                            else
                            {
                                Console.WriteLine("La pelicula en el horario deseado y sala deseada aun no ha sido ingresada.\r\nPara agregar entre al menú ingresar.");
                                Console.ReadKey();
                                break;
                            }

                        case "3":
                            if (Sala[2].peliculasSala[1].LlenoAdmin == true)
                            {
                                Console.WriteLine();
                                Console.WriteLine("Nombre actual de la pelicula:");
                                Console.WriteLine(Sala[2].peliculasSala[1].Nombre);
                                Console.WriteLine("Precio actual de la pelicula:");
                                Console.WriteLine(Sala[2].peliculasSala[1].PrecioTicket.ToString());
                                Console.WriteLine();
                                Console.WriteLine("Ingrese el nuevo nombre de la pelicula:");
                                Sala[2].peliculasSala[1].Nombre = Console.ReadLine();
                                Console.WriteLine("Ingrese el nuevo precio:");
                                try
                                {
                                    Sala[2].peliculasSala[1].PrecioTicket = Convert.ToUInt32(Console.ReadLine());
                                }
                                catch
                                {
                                    Console.WriteLine("El precio del ticket debe ser un entero positivo, intentelo de nuevo.");
                                    Console.ReadKey();
                                    Modificar();
                                }
                                break;
                            }
                            else
                            {
                                Console.WriteLine("La pelicula en el horario deseado y sala deseada aun no ha sido ingresada.\r\nPara agregar entre al menú ingresar.");
                                Console.ReadKey();
                                break;
                            }

                        case "5":
                            if (Sala[2].peliculasSala[2].LlenoAdmin == true)
                            {
                                Console.WriteLine();
                                Console.WriteLine("Nombre actual de la pelicula:");
                                Console.WriteLine(Sala[2].peliculasSala[2].Nombre);
                                Console.WriteLine("Precio actual de la pelicula:");
                                Console.WriteLine(Sala[2].peliculasSala[2].PrecioTicket.ToString());
                                Console.WriteLine();
                                Console.WriteLine("Ingrese el nuevo nombre de la pelicula:");
                                Sala[2].peliculasSala[2].Nombre = Console.ReadLine();
                                Console.WriteLine("Ingrese el nuevo precio:");
                                try
                                {
                                    Sala[2].peliculasSala[2].PrecioTicket = Convert.ToUInt32(Console.ReadLine());
                                }
                                catch
                                {
                                    Console.WriteLine("El precio del ticket debe ser un entero positivo, intentelo de nuevo.");
                                    Console.ReadKey();
                                    Modificar();
                                }
                                break;
                            }
                            else
                            {
                                Console.WriteLine("La pelicula en el horario deseado y sala deseada aun no ha sido ingresada.\r\nPara agregar entre al menú ingresar.");
                                Console.ReadKey();
                                break;
                            }

                        case "7":
                            if (Sala[2].peliculasSala[3].LlenoAdmin == true)
                            {
                                Console.WriteLine();
                                Console.WriteLine("Nombre actual de la pelicula:");
                                Console.WriteLine(Sala[2].peliculasSala[3].Nombre);
                                Console.WriteLine("Precio actual de la pelicula:");
                                Console.WriteLine(Sala[2].peliculasSala[3].PrecioTicket.ToString());
                                Console.WriteLine();
                                Console.WriteLine("Ingrese el nuevo nombre de la pelicula:");
                                Sala[2].peliculasSala[3].Nombre = Console.ReadLine();
                                Console.WriteLine("Ingrese el nuevo precio:");
                                try
                                {
                                    Sala[2].peliculasSala[3].PrecioTicket = Convert.ToUInt32(Console.ReadLine());
                                }
                                catch
                                {
                                    Console.WriteLine("El precio del ticket debe ser un entero positivo, intentelo de nuevo.");
                                    Console.ReadKey();
                                    Modificar();
                                }
                                break;
                            }
                            else
                            {
                                Console.WriteLine("La pelicula en el horario deseado y sala deseada aun no ha sido ingresada.\r\nPara agregar entre al menú ingresar.");
                                Console.ReadKey();
                                break;
                            }

                        case "9":
                            if (Sala[2].peliculasSala[4].LlenoAdmin == true)
                            {
                                Console.WriteLine();
                                Console.WriteLine("Nombre actual de la pelicula:");
                                Console.WriteLine(Sala[2].peliculasSala[4].Nombre);
                                Console.WriteLine("Precio actual de la pelicula:");
                                Console.WriteLine(Sala[2].peliculasSala[4].PrecioTicket.ToString());
                                Console.WriteLine();
                                Console.WriteLine("Ingrese el nuevo nombre de la pelicula:");
                                Sala[2].peliculasSala[4].Nombre = Console.ReadLine();
                                Console.WriteLine("Ingrese el nuevo precio:");
                                try
                                {
                                    Sala[2].peliculasSala[4].PrecioTicket = Convert.ToUInt32(Console.ReadLine());
                                }
                                catch
                                {
                                    Console.WriteLine("El precio del ticket debe ser un entero positivo, intentelo de nuevo.");
                                    Console.ReadKey();
                                    Modificar();
                                }
                                break;
                            }
                            else
                            {
                                Console.WriteLine("La pelicula en el horario deseado y sala deseada aun no ha sido ingresada.\r\nPara agregar entre al menú ingresar.");
                                Console.ReadKey();
                                break;
                            }

                        default:
                            Console.WriteLine("Horario no existe, intentelo de nuevo.");
                            Console.ReadKey();
                            Modificar();
                            break;
                    }
                    break;

                case "4":
                    Console.WriteLine("Ingrese la hora de inicio:");
                    switch (Console.ReadLine())
                    {
                        case "1":
                            if (Sala[3].peliculasSala[0].LlenoAdmin == true)
                            {
                                Console.WriteLine();
                                Console.WriteLine("Nombre actual de la pelicula:");
                                Console.WriteLine(Sala[3].peliculasSala[0].Nombre);
                                Console.WriteLine("Precio actual de la pelicula:");
                                Console.WriteLine(Sala[3].peliculasSala[0].PrecioTicket.ToString());
                                Console.WriteLine();
                                Console.WriteLine("Ingrese el nuevo nombre de la pelicula:");
                                Sala[3].peliculasSala[0].Nombre = Console.ReadLine();
                                Console.WriteLine("Ingrese el nuevo precio:");
                                try
                                {
                                    Sala[3].peliculasSala[0].PrecioTicket = Convert.ToUInt32(Console.ReadLine());
                                }
                                catch
                                {
                                    Console.WriteLine("El precio del ticket debe ser un entero positivo, intentelo de nuevo.");
                                    Console.ReadKey();
                                    Modificar();
                                }
                                break;
                            }
                            else
                            {
                                Console.WriteLine("La pelicula en el horario deseado y sala deseada aun no ha sido ingresada.\r\nPara agregar entre al menú ingresar.");
                                Console.ReadKey();
                                break;
                            }

                        case "3":
                            if (Sala[3].peliculasSala[1].LlenoAdmin == true)
                            {
                                Console.WriteLine();
                                Console.WriteLine("Nombre actual de la pelicula:");
                                Console.WriteLine(Sala[3].peliculasSala[1].Nombre);
                                Console.WriteLine("Precio actual de la pelicula:");
                                Console.WriteLine(Sala[3].peliculasSala[1].PrecioTicket.ToString());
                                Console.WriteLine();
                                Console.WriteLine("Ingrese el nuevo nombre de la pelicula:");
                                Sala[3].peliculasSala[1].Nombre = Console.ReadLine();
                                Console.WriteLine("Ingrese el nuevo precio:");
                                try
                                {
                                    Sala[3].peliculasSala[1].PrecioTicket = Convert.ToUInt32(Console.ReadLine());
                                }
                                catch
                                {
                                    Console.WriteLine("El precio del ticket debe ser un entero positivo, intentelo de nuevo.");
                                    Console.ReadKey();
                                    Modificar();
                                }
                                break;
                            }
                            else
                            {
                                Console.WriteLine("La pelicula en el horario deseado y sala deseada aun no ha sido ingresada.\r\nPara agregar entre al menú ingresar.");
                                Console.ReadKey();
                                break;
                            }

                        case "5":
                            if (Sala[3].peliculasSala[2].LlenoAdmin == true)
                            {
                                Console.WriteLine();
                                Console.WriteLine("Nombre actual de la pelicula:");
                                Console.WriteLine(Sala[3].peliculasSala[2].Nombre);
                                Console.WriteLine("Precio actual de la pelicula:");
                                Console.WriteLine(Sala[3].peliculasSala[2].PrecioTicket.ToString());
                                Console.WriteLine();
                                Console.WriteLine("Ingrese el nuevo nombre de la pelicula:");
                                Sala[3].peliculasSala[2].Nombre = Console.ReadLine();
                                Console.WriteLine("Ingrese el nuevo precio:");
                                try
                                {
                                    Sala[3].peliculasSala[2].PrecioTicket = Convert.ToUInt32(Console.ReadLine());
                                }
                                catch
                                {
                                    Console.WriteLine("El precio del ticket debe ser un entero positivo, intentelo de nuevo.");
                                    Console.ReadKey();
                                    Modificar();
                                }
                                break;
                            }
                            else
                            {
                                Console.WriteLine("La pelicula en el horario deseado y sala deseada aun no ha sido ingresada.\r\nPara agregar entre al menú ingresar.");
                                Console.ReadKey();
                                break;
                            }

                        case "7":
                            if (Sala[3].peliculasSala[3].LlenoAdmin == true)
                            {
                                Console.WriteLine();
                                Console.WriteLine("Nombre actual de la pelicula:");
                                Console.WriteLine(Sala[3].peliculasSala[3].Nombre);
                                Console.WriteLine("Precio actual de la pelicula:");
                                Console.WriteLine(Sala[3].peliculasSala[3].PrecioTicket.ToString());
                                Console.WriteLine();
                                Console.WriteLine("Ingrese el nuevo nombre de la pelicula:");
                                Sala[3].peliculasSala[3].Nombre = Console.ReadLine();
                                Console.WriteLine("Ingrese el nuevo precio:");
                                try
                                {
                                    Sala[3].peliculasSala[3].PrecioTicket = Convert.ToUInt32(Console.ReadLine());
                                }
                                catch
                                {
                                    Console.WriteLine("El precio del ticket debe ser un entero positivo, intentelo de nuevo.");
                                    Console.ReadKey();
                                    Modificar();
                                }
                                break;
                            }
                            else
                            {
                                Console.WriteLine("La pelicula en el horario deseado y sala deseada aun no ha sido ingresada.\r\nPara agregar entre al menú ingresar.");
                                Console.ReadKey();
                                break;
                            }

                        case "9":
                            if (Sala[3].peliculasSala[4].LlenoAdmin == true)
                            {
                                Console.WriteLine();
                                Console.WriteLine("Nombre actual de la pelicula:");
                                Console.WriteLine(Sala[3].peliculasSala[4].Nombre);
                                Console.WriteLine("Precio actual de la pelicula:");
                                Console.WriteLine(Sala[3].peliculasSala[4].PrecioTicket.ToString());
                                Console.WriteLine();
                                Console.WriteLine("Ingrese el nuevo nombre de la pelicula:");
                                Sala[3].peliculasSala[4].Nombre = Console.ReadLine();
                                Console.WriteLine("Ingrese el nuevo precio:");
                                try
                                {
                                    Sala[3].peliculasSala[4].PrecioTicket = Convert.ToUInt32(Console.ReadLine());
                                }
                                catch
                                {
                                    Console.WriteLine("El precio del ticket debe ser un entero positivo, intentelo de nuevo.");
                                    Console.ReadKey();
                                    Modificar();
                                }
                                break;
                            }
                            else
                            {
                                Console.WriteLine("La pelicula en el horario deseado y sala deseada aun no ha sido ingresada.\r\nPara agregar entre al menú ingresar.");
                                Console.ReadKey();
                                break;
                            }

                        default:
                            Console.WriteLine("Horario no existe, intentelo de nuevo.");
                            Console.ReadKey();
                            Modificar();
                            break;
                    }
                    break;

                default:
                    Console.WriteLine("Sala no existe, intente de nuevo");
                    Console.ReadKey();
                    Modificar();
                    break;
            }
        }


        //Metodo Internet.
        static void imprimir(string[,] matriz)
         {            
             for (int f = 0; f< 8; f++)
             {
                 for (int c = 0; c< 10; c++)
                 {
                     Console.Write(" {0} |",matriz[f, c]);
                 }
                 Console.WriteLine("");
             }
         }

        static bool RevisarAsientos(int sala, int hora)
        {
            for (int a = 0; a < 8; a++)
            {
                for (int b = 0; b < 10; b++)
                {
                    if (Sala[sala].peliculasSala[hora].TablaVerdad[a, b] == true)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        static List<ResumenCompra> Factura = new List<ResumenCompra>();



        //Compra de peliculas. COMPAR METODOS EN TODO.
        static private void Compra()
        {
            if (contadorEntradas < 9)
            {
                Console.Clear();
                Console.WriteLine("*.*=============*.*");
                Console.WriteLine("   APOLLO CINEMA   ");
                Console.WriteLine("*.*=============*.*");
                Console.WriteLine();
                Console.WriteLine("   .:COMPRA BOLETOS:.");
                Console.WriteLine();
                Console.WriteLine("El nombre de la película:");
                string nombre = Console.ReadLine();
                string resultadoBusqueda = "";

                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (Sala[i].peliculasSala[j].Nombre == nombre)
                        {
                            resultadoBusqueda += Sala[i].peliculasSala[j].Nombre + " Sala: " + Sala[i].peliculasSala[j].Sala + " Horario: " + Sala[i].peliculasSala[j].Horario + " Precio: " + Sala[i].peliculasSala[j].PrecioTicket + "." + "\r\n";
                        }
                    }
                }
                Console.WriteLine();
                Console.WriteLine("Resultados:");
                Console.WriteLine();
                Console.WriteLine(resultadoBusqueda);

                Console.WriteLine();
                Console.WriteLine("COMPRA:");

                Console.WriteLine("Ingrese el número de sala:");
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.WriteLine("Ingrese la hora de inicio:");
                        switch (Console.ReadLine())
                        {
                            case "1":
                                if (RevisarAsientos(0, 0))
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("Asientos:");
                                    imprimir(Sala[0].peliculasSala[0].Asientos);
                                    string eleccion = Console.ReadLine();
                                    for (int x = 0; x < 8; x++)
                                    {
                                        for (int y = 0; y < 10; y++)
                                        {
                                            if (Sala[0].peliculasSala[0].Asientos[x, y] == eleccion && Sala[0].peliculasSala[0].TablaVerdad[x, y] == true)
                                            {
                                                Sala[0].peliculasSala[0].Asientos[x, y] = "X";
                                                Sala[0].peliculasSala[0].TablaVerdad[x, y] = false;
                                                contadorEntradas++;
                                                Console.WriteLine();
                                                Console.WriteLine("Ingrese el tipo de boleto:");
                                                Console.WriteLine("1 - Niños");
                                                Console.WriteLine("2 - Adulto Mayor");
                                                Console.WriteLine("3 - Adultos");
                                                string descuento = Console.ReadLine();
                                                if (descuento == "1")
                                                {
                                                    Console.WriteLine("Descuento: 10%");
                                                    Sala[0].peliculasSala[0].PrecioConDescuento[x, y] = (Sala[0].peliculasSala[0].PrecioTicket) - ((Sala[0].peliculasSala[0].PrecioTicket) * 0.10);
                                                    subTotal += Sala[0].peliculasSala[0].PrecioConDescuento[x, y];
                                                    contadorNiño++;

                                                }
                                                else if (descuento == "2")
                                                {
                                                    Console.WriteLine("Descuento: 20%");
                                                    Sala[0].peliculasSala[0].PrecioConDescuento[x, y] = (Sala[0].peliculasSala[0].PrecioTicket) - ((Sala[0].peliculasSala[0].PrecioTicket) * 0.20);
                                                    subTotal += Sala[0].peliculasSala[0].PrecioConDescuento[x, y];
                                                    contadorAdultoM++;
                                                }
                                                else if (descuento == "3")
                                                {
                                                    Console.WriteLine("Descuento: 0%");
                                                    Sala[0].peliculasSala[0].PrecioConDescuento[x, y] = (Sala[0].peliculasSala[0].PrecioTicket);
                                                    subTotal += Sala[0].peliculasSala[0].PrecioConDescuento[x, y];
                                                    contadorAdulto++;
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Opcion no valida");
                                                }

                                                //Nueva compra.
                                                Console.WriteLine();
                                                Console.WriteLine("¿Desea comprar más boletos? [Y / N: CualquierTecla]");
                                                string nuevo = Console.ReadLine();
                                                if (nuevo == "Y" || nuevo == "y")
                                                {
                                                    Compra();
                                                }
                                                else
                                                {
                                                    Factura.Add(new ResumenCompra());
                                                    Factura[Factura.Count - 1].NombrePelicula += Sala[0].peliculasSala[0].Nombre + " ";
                                                    Factura[Factura.Count - 1].HoraFuncion += Sala[0].peliculasSala[0].Horario + " ";
                                                    Factura[Factura.Count - 1].Sala += Sala[0].peliculasSala[0].Sala + " ";
                                                    Factura[Factura.Count - 1].EntradasNiño = contadorNiño;
                                                    Factura[Factura.Count - 1].EntradasAdultoMayor = contadorAdultoM;
                                                    Factura[Factura.Count - 1].EntradasAdulto = contadorAdulto;
                                                    Factura[Factura.Count - 1].subTotal = subTotal;
                                                    if (Factura.Count >= 5)
                                                    {
                                                        Factura[Factura.Count - 1].Total = subTotal - (subTotal * 0.05);
                                                    }
                                                    else
                                                    {
                                                        Factura[Factura.Count - 1].Total = subTotal;
                                                    }
                                                    Console.WriteLine("Presione cualquier tecla para ir a la factura.");
                                                    Console.ReadKey();

                                                    Console.Clear();

                                                    for (int F = 0; F < Factura.Count; F++)
                                                    {
                                                        Console.WriteLine("Pelicula: " + Factura[F].NombrePelicula);
                                                        Console.WriteLine("Hora Funcion: " + Factura[F].HoraFuncion);
                                                        Console.WriteLine("Sala: " + Factura[F].Sala);
                                                        Console.WriteLine("Cantidad entradas niño: " + Factura[F].EntradasNiño);
                                                        Console.WriteLine("Cantidad entradas adulto mayor: " + Factura[F].EntradasAdultoMayor);
                                                        Console.WriteLine("Cantidad entradas adulto: " + Factura[F].EntradasAdulto);
                                                        Console.WriteLine("Cantidad entradas subtotal: " + Factura[F].subTotal);
                                                        if (contadorEntradas>=5)
                                                        {
                                                            Console.WriteLine("Descuento por comprar mas de 5 entradas: " + (Factura[F].subTotal * 0.05));
                                                        }
                                                        Console.WriteLine("Descuento por comprar mas de 5 entradas: 0");
                                                        Console.WriteLine("Cantidad entradas total: " + Factura[F].Total);
                                                        Console.WriteLine("Hora Compra: " + DateTime.Now.ToString());
                                                    }

                                                    Console.WriteLine();
                                                    Console.WriteLine("Presione cualquier tecla para regresar al menu");
                                                    Console.ReadKey();
                                                    //Menu.
                                                    Console.Clear();
                                                    M_Principal();
                                                }

                                            }
                                            else
                                            {
                                                if (x==7 && y==9)
                                                {
                                                    if (Sala[0].peliculasSala[0].TablaVerdad[x, y] == false)
                                                    {
                                                        Console.WriteLine("Entrada invalida o Entrada vendida, intentelo de nuevo");
                                                        Console.ReadKey();
                                                        Compra();
                                                    }
                                                    if (Sala[0].peliculasSala[0].Asientos[x, y] != eleccion)
                                                    {
                                                        Console.WriteLine("Entrada invalida o Entrada vendida, intentelo de nuevo");
                                                        Console.ReadKey();
                                                        Compra();
                                                    }
                                                }

                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("NO HAY ASIENTOS DISPONIBLES");
                                }
                                
                                break;

                            case "3":
                                if (RevisarAsientos(0, 1))
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("Asientos:");
                                    imprimir(Sala[0].peliculasSala[1].Asientos);
                                    string eleccion = Console.ReadLine();
                                    for (int x = 0; x < 8; x++)
                                    {
                                        for (int y = 0; y < 10; y++)
                                        {
                                            if (Sala[0].peliculasSala[1].Asientos[x, y] == eleccion && Sala[0].peliculasSala[1].TablaVerdad[x, y] == true)
                                            {
                                                Sala[0].peliculasSala[1].Asientos[x, y] = "X";
                                                Sala[0].peliculasSala[1].TablaVerdad[x, y] = false;
                                                contadorEntradas++;
                                                Console.WriteLine();
                                                Console.WriteLine("Ingrese el tipo de boleto:");
                                                Console.WriteLine("1 - Niños");
                                                Console.WriteLine("2 - Adulto Mayor");
                                                Console.WriteLine("3 - Adultos");
                                                string descuento = Console.ReadLine();
                                                if (descuento == "1")
                                                {
                                                    Console.WriteLine("Descuento: 10%");
                                                    Sala[0].peliculasSala[1].PrecioConDescuento[x, y] = (Sala[0].peliculasSala[1].PrecioTicket) - ((Sala[0].peliculasSala[1].PrecioTicket) * 0.10);
                                                    subTotal += Sala[0].peliculasSala[1].PrecioConDescuento[x, y];
                                                    contadorNiño++;

                                                }
                                                else if (descuento == "2")
                                                {
                                                    Console.WriteLine("Descuento: 20%");
                                                    Sala[0].peliculasSala[1].PrecioConDescuento[x, y] = (Sala[0].peliculasSala[1].PrecioTicket) - ((Sala[0].peliculasSala[1].PrecioTicket) * 0.20);
                                                    subTotal += Sala[0].peliculasSala[1].PrecioConDescuento[x, y];
                                                    contadorAdultoM++;
                                                }
                                                else if (descuento == "3")
                                                {
                                                    Console.WriteLine("Descuento: 0%");
                                                    Sala[0].peliculasSala[1].PrecioConDescuento[x, y] = (Sala[0].peliculasSala[1].PrecioTicket);
                                                    subTotal += Sala[0].peliculasSala[1].PrecioConDescuento[x, y];
                                                    contadorAdulto++;
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Opcion no valida");
                                                }

                                                //Nueva compra.
                                                Console.WriteLine();
                                                Console.WriteLine("¿Desea comprar más boletos? [Y / N: CualquierTecla]");
                                                string nuevo = Console.ReadLine();
                                                if (nuevo == "Y" || nuevo == "y")
                                                {
                                                    Compra();
                                                }
                                                else
                                                {
                                                    Factura.Add(new ResumenCompra());
                                                    Factura[Factura.Count - 1].NombrePelicula = Sala[0].peliculasSala[1].Nombre;
                                                    Factura[Factura.Count - 1].HoraFuncion = Sala[0].peliculasSala[1].Horario;
                                                    Factura[Factura.Count - 1].Sala = Sala[0].peliculasSala[1].Sala;
                                                    Factura[Factura.Count - 1].EntradasNiño = contadorNiño;
                                                    Factura[Factura.Count - 1].EntradasAdultoMayor = contadorAdultoM;
                                                    Factura[Factura.Count - 1].EntradasAdulto = contadorAdulto;
                                                    Factura[Factura.Count - 1].subTotal = subTotal;
                                                    if (Factura.Count >= 5)
                                                    {
                                                        Factura[Factura.Count - 1].Total = subTotal - (subTotal * 0.05);
                                                    }
                                                    else
                                                    {
                                                        Factura[Factura.Count - 1].Total = subTotal;
                                                    }
                                                    Console.WriteLine("Presione cualquier tecla para ir a la factura.");
                                                    Console.ReadKey();

                                                    Console.Clear();

                                                    for (int F = 0; F < Factura.Count; F++)
                                                    {
                                                        Console.WriteLine("Pelicula: " + Factura[F].NombrePelicula);
                                                        Console.WriteLine("Hora Funcion: " + Factura[F].HoraFuncion);
                                                        Console.WriteLine("Sala: " + Factura[F].Sala);
                                                        Console.WriteLine("Cantidad entradas niño: " + Factura[F].EntradasNiño);
                                                        Console.WriteLine("Cantidad entradas adulto mayor: " + Factura[F].EntradasAdultoMayor);
                                                        Console.WriteLine("Cantidad entradas adulto: " + Factura[F].EntradasAdulto);
                                                        Console.WriteLine("Cantidad entradas subtotal: " + Factura[F].subTotal);
                                                        if (contadorEntradas >= 5)
                                                        {
                                                            Console.WriteLine("Descuento por comprar mas de 5 entradas: " + (Factura[F].subTotal * 0.05));
                                                        }
                                                        Console.WriteLine("Descuento por comprar mas de 5 entradas: 0");
                                                        Console.WriteLine("Cantidad entradas total: " + Factura[F].Total);
                                                        Console.WriteLine("Hora Compra: " + DateTime.Now.ToString());
                                                    }

                                                    Console.WriteLine();
                                                    Console.WriteLine("Presione cualquier tecla para regresar al menu");
                                                    Console.ReadKey();
                                                    //Menu.
                                                    Console.Clear();
                                                    M_Principal();
                                                }

                                            }
                                            else
                                            {
                                                if (x == 7 && y == 9)
                                                {
                                                    if (Sala[0].peliculasSala[1].TablaVerdad[x, y] == false)
                                                    {
                                                        Console.WriteLine("Entrada invalida o Entrada vendida, intentelo de nuevo");
                                                        Console.ReadKey();
                                                        Compra();
                                                    }
                                                    if (Sala[0].peliculasSala[1].Asientos[x, y] != eleccion)
                                                    {
                                                        Console.WriteLine("Entrada invalida o Entrada vendida, intentelo de nuevo");
                                                        Console.ReadKey();
                                                        Compra();
                                                    }
                                                }

                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("NO HAY ASIENTOS DISPONIBLES");
                                }

                                break;

                            case "5":
                                if (RevisarAsientos(0, 2))
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("Asientos:");
                                    imprimir(Sala[0].peliculasSala[2].Asientos);
                                    string eleccion = Console.ReadLine();
                                    for (int x = 0; x < 8; x++)
                                    {
                                        for (int y = 0; y < 10; y++)
                                        {
                                            if (Sala[0].peliculasSala[2].Asientos[x, y] == eleccion && Sala[0].peliculasSala[2].TablaVerdad[x, y] == true)
                                            {
                                                Sala[0].peliculasSala[2].Asientos[x, y] = "X";
                                                Sala[0].peliculasSala[2].TablaVerdad[x, y] = false;
                                                contadorEntradas++;
                                                Console.WriteLine();
                                                Console.WriteLine("Ingrese el tipo de boleto:");
                                                Console.WriteLine("1 - Niños");
                                                Console.WriteLine("2 - Adulto Mayor");
                                                Console.WriteLine("3 - Adultos");
                                                string descuento = Console.ReadLine();
                                                if (descuento == "1")
                                                {
                                                    Console.WriteLine("Descuento: 10%");
                                                    Sala[0].peliculasSala[2].PrecioConDescuento[x, y] = (Sala[0].peliculasSala[2].PrecioTicket) - ((Sala[0].peliculasSala[2].PrecioTicket) * 0.10);
                                                    subTotal += Sala[0].peliculasSala[2].PrecioConDescuento[x, y];
                                                    contadorNiño++;

                                                }
                                                else if (descuento == "2")
                                                {
                                                    Console.WriteLine("Descuento: 20%");
                                                    Sala[0].peliculasSala[2].PrecioConDescuento[x, y] = (Sala[0].peliculasSala[2].PrecioTicket) - ((Sala[0].peliculasSala[2].PrecioTicket) * 0.20);
                                                    subTotal += Sala[0].peliculasSala[2].PrecioConDescuento[x, y];
                                                    contadorAdultoM++;
                                                }
                                                else if (descuento == "3")
                                                {
                                                    Console.WriteLine("Descuento: 0%");
                                                    Sala[0].peliculasSala[2].PrecioConDescuento[x, y] = (Sala[0].peliculasSala[2].PrecioTicket);
                                                    subTotal += Sala[0].peliculasSala[2].PrecioConDescuento[x, y];
                                                    contadorAdulto++;
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Opcion no valida");
                                                }

                                                //Nueva compra.
                                                Console.WriteLine();
                                                Console.WriteLine("¿Desea comprar más boletos? [Y / N: CualquierTecla]");
                                                string nuevo = Console.ReadLine();
                                                if (nuevo == "Y" || nuevo == "y")
                                                {
                                                    Compra();
                                                }
                                                else
                                                {
                                                    Factura.Add(new ResumenCompra());
                                                    Factura[Factura.Count - 1].NombrePelicula = Sala[0].peliculasSala[2].Nombre;
                                                    Factura[Factura.Count - 1].HoraFuncion = Sala[0].peliculasSala[2].Horario;
                                                    Factura[Factura.Count - 1].Sala = Sala[0].peliculasSala[2].Sala;
                                                    Factura[Factura.Count - 1].EntradasNiño = contadorNiño;
                                                    Factura[Factura.Count - 1].EntradasAdultoMayor = contadorAdultoM;
                                                    Factura[Factura.Count - 1].EntradasAdulto = contadorAdulto;
                                                    Factura[Factura.Count - 1].subTotal = subTotal;
                                                    if (Factura.Count >= 5)
                                                    {
                                                        Factura[Factura.Count - 1].Total = subTotal - (subTotal * 0.05);
                                                    }
                                                    else
                                                    {
                                                        Factura[Factura.Count - 1].Total = subTotal;
                                                    }
                                                    Console.WriteLine("Presione cualquier tecla para ir a la factura.");
                                                    Console.ReadKey();

                                                    Console.Clear();

                                                    for (int F = 0; F < Factura.Count; F++)
                                                    {
                                                        Console.WriteLine("Pelicula: " + Factura[F].NombrePelicula);
                                                        Console.WriteLine("Hora Funcion: " + Factura[F].HoraFuncion);
                                                        Console.WriteLine("Sala: " + Factura[F].Sala);
                                                        Console.WriteLine("Cantidad entradas niño: " + Factura[F].EntradasNiño);
                                                        Console.WriteLine("Cantidad entradas adulto mayor: " + Factura[F].EntradasAdultoMayor);
                                                        Console.WriteLine("Cantidad entradas adulto: " + Factura[F].EntradasAdulto);
                                                        Console.WriteLine("Cantidad entradas subtotal: " + Factura[F].subTotal);
                                                        if (contadorEntradas >= 5)
                                                        {
                                                            Console.WriteLine("Descuento por comprar mas de 5 entradas: " + (Factura[F].subTotal * 0.05));
                                                        }
                                                        Console.WriteLine("Descuento por comprar mas de 5 entradas: 0");
                                                        Console.WriteLine("Cantidad entradas total: " + Factura[F].Total);
                                                        Console.WriteLine("Hora Compra: " + DateTime.Now.ToString());

                                                    }

                                                    Console.WriteLine();
                                                    Console.WriteLine("Presione cualquier tecla para regresar al menu");
                                                    Console.ReadKey();
                                                    //Menu.
                                                    Console.Clear();
                                                    M_Principal();
                                                }

                                            }
                                            else
                                            {
                                                if (x == 7 && y == 9)
                                                {
                                                    if (Sala[0].peliculasSala[2].TablaVerdad[x, y] == false)
                                                    {
                                                        Console.WriteLine("Entrada invalida o Entrada vendida, intentelo de nuevo");
                                                        Console.ReadKey();
                                                        Compra();
                                                    }
                                                    if (Sala[0].peliculasSala[2].Asientos[x, y] != eleccion)
                                                    {
                                                        Console.WriteLine("Entrada invalida o Entrada vendida, intentelo de nuevo");
                                                        Console.ReadKey();
                                                        Compra();
                                                    }
                                                }

                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("NO HAY ASIENTOS DISPONIBLES");
                                }

                                break;

                            case "7":
                                if (RevisarAsientos(0, 3))
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("Asientos:");
                                    imprimir(Sala[0].peliculasSala[3].Asientos);
                                    string eleccion = Console.ReadLine();
                                    for (int x = 0; x < 8; x++)
                                    {
                                        for (int y = 0; y < 10; y++)
                                        {
                                            if (Sala[0].peliculasSala[3].Asientos[x, y] == eleccion && Sala[0].peliculasSala[3].TablaVerdad[x, y] == true)
                                            {
                                                Sala[0].peliculasSala[3].Asientos[x, y] = "X";
                                                Sala[0].peliculasSala[3].TablaVerdad[x, y] = false;
                                                contadorEntradas++;
                                                Console.WriteLine();
                                                Console.WriteLine("Ingrese el tipo de boleto:");
                                                Console.WriteLine("1 - Niños");
                                                Console.WriteLine("2 - Adulto Mayor");
                                                Console.WriteLine("3 - Adultos");
                                                string descuento = Console.ReadLine();
                                                if (descuento == "1")
                                                {
                                                    Console.WriteLine("Descuento: 10%");
                                                    Sala[0].peliculasSala[3].PrecioConDescuento[x, y] = (Sala[0].peliculasSala[3].PrecioTicket) - ((Sala[0].peliculasSala[3].PrecioTicket) * 0.10);
                                                    subTotal += Sala[0].peliculasSala[3].PrecioConDescuento[x, y];
                                                    contadorNiño++;

                                                }
                                                else if (descuento == "2")
                                                {
                                                    Console.WriteLine("Descuento: 20%");
                                                    Sala[0].peliculasSala[3].PrecioConDescuento[x, y] = (Sala[0].peliculasSala[3].PrecioTicket) - ((Sala[0].peliculasSala[3].PrecioTicket) * 0.20);
                                                    subTotal += Sala[0].peliculasSala[3].PrecioConDescuento[x, y];
                                                    contadorAdultoM++;
                                                }
                                                else if (descuento == "3")
                                                {
                                                    Console.WriteLine("Descuento: 0%");
                                                    Sala[0].peliculasSala[3].PrecioConDescuento[x, y] = (Sala[0].peliculasSala[3].PrecioTicket);
                                                    subTotal += Sala[0].peliculasSala[3].PrecioConDescuento[x, y];
                                                    contadorAdulto++;
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Opcion no valida");
                                                }

                                                //Nueva compra.
                                                Console.WriteLine();
                                                Console.WriteLine("¿Desea comprar más boletos? [Y / N: CualquierTecla]");
                                                string nuevo = Console.ReadLine();
                                                if (nuevo == "Y" || nuevo == "y")
                                                {
                                                    Compra();
                                                }
                                                else
                                                {
                                                    Factura.Add(new ResumenCompra());
                                                    Factura[Factura.Count - 1].NombrePelicula = Sala[0].peliculasSala[3].Nombre;
                                                    Factura[Factura.Count - 1].HoraFuncion = Sala[0].peliculasSala[3].Horario;
                                                    Factura[Factura.Count - 1].Sala = Sala[0].peliculasSala[3].Sala;
                                                    Factura[Factura.Count - 1].EntradasNiño = contadorNiño;
                                                    Factura[Factura.Count - 1].EntradasAdultoMayor = contadorAdultoM;
                                                    Factura[Factura.Count - 1].EntradasAdulto = contadorAdulto;
                                                    Factura[Factura.Count - 1].subTotal = subTotal;
                                                    if (Factura.Count >= 5)
                                                    {
                                                        Factura[Factura.Count - 1].Total = subTotal - (subTotal * 0.05);
                                                    }
                                                    else
                                                    {
                                                        Factura[Factura.Count - 1].Total = subTotal;
                                                    }
                                                    Console.WriteLine("Presione cualquier tecla para ir a la factura.");
                                                    Console.ReadKey();

                                                    Console.Clear();

                                                    for (int F = 0; F < Factura.Count; F++)
                                                    {
                                                        Console.WriteLine("Pelicula: " + Factura[F].NombrePelicula);
                                                        Console.WriteLine("Hora Funcion: " + Factura[F].HoraFuncion);
                                                        Console.WriteLine("Sala: " + Factura[F].Sala);
                                                        Console.WriteLine("Cantidad entradas niño: " + Factura[F].EntradasNiño);
                                                        Console.WriteLine("Cantidad entradas adulto mayor: " + Factura[F].EntradasAdultoMayor);
                                                        Console.WriteLine("Cantidad entradas adulto: " + Factura[F].EntradasAdulto);
                                                        Console.WriteLine("Cantidad entradas subtotal: " + Factura[F].subTotal);
                                                        if (contadorEntradas >= 5)
                                                        {
                                                            Console.WriteLine("Descuento por comprar mas de 5 entradas: " + (Factura[F].subTotal * 0.05));
                                                        }
                                                        Console.WriteLine("Descuento por comprar mas de 5 entradas: 0");
                                                        Console.WriteLine("Cantidad entradas total: " + Factura[F].Total);
                                                        Console.WriteLine("Hora Compra: " + DateTime.Now.ToString());

                                                    }

                                                    Console.WriteLine();
                                                    Console.WriteLine("Presione cualquier tecla para regresar al menu");
                                                    Console.ReadKey();
                                                    //Menu.
                                                    Console.Clear();
                                                    M_Principal();
                                                }

                                            }
                                            else
                                            {
                                                if (x == 7 && y == 9)
                                                {
                                                    if (Sala[0].peliculasSala[3].TablaVerdad[x, y] == false)
                                                    {
                                                        Console.WriteLine("Entrada invalida o Entrada vendida, intentelo de nuevo");
                                                        Console.ReadKey();
                                                        Compra();
                                                    }
                                                    if (Sala[0].peliculasSala[3].Asientos[x, y] != eleccion)
                                                    {
                                                        Console.WriteLine("Entrada invalida o Entrada vendida, intentelo de nuevo");
                                                        Console.ReadKey();
                                                        Compra();
                                                    }
                                                }

                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("NO HAY ASIENTOS DISPONIBLES");
                                }

                                break;

                            case "9":
                                if (RevisarAsientos(0, 4))
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("Asientos:");
                                    imprimir(Sala[0].peliculasSala[4].Asientos);
                                    string eleccion = Console.ReadLine();
                                    for (int x = 0; x < 8; x++)
                                    {
                                        for (int y = 0; y < 10; y++)
                                        {
                                            if (Sala[0].peliculasSala[4].Asientos[x, y] == eleccion && Sala[0].peliculasSala[4].TablaVerdad[x, y] == true)
                                            {
                                                Sala[0].peliculasSala[4].Asientos[x, y] = "X";
                                                Sala[0].peliculasSala[4].TablaVerdad[x, y] = false;
                                                contadorEntradas++;
                                                Console.WriteLine();
                                                Console.WriteLine("Ingrese el tipo de boleto:");
                                                Console.WriteLine("1 - Niños");
                                                Console.WriteLine("2 - Adulto Mayor");
                                                Console.WriteLine("3 - Adultos");
                                                string descuento = Console.ReadLine();
                                                if (descuento == "1")
                                                {
                                                    Console.WriteLine("Descuento: 10%");
                                                    Sala[0].peliculasSala[4].PrecioConDescuento[x, y] = (Sala[0].peliculasSala[4].PrecioTicket) - ((Sala[0].peliculasSala[4].PrecioTicket) * 0.10);
                                                    subTotal += Sala[0].peliculasSala[4].PrecioConDescuento[x, y];
                                                    contadorNiño++;

                                                }
                                                else if (descuento == "2")
                                                {
                                                    Console.WriteLine("Descuento: 20%");
                                                    Sala[0].peliculasSala[4].PrecioConDescuento[x, y] = (Sala[0].peliculasSala[4].PrecioTicket) - ((Sala[0].peliculasSala[4].PrecioTicket) * 0.20);
                                                    subTotal += Sala[0].peliculasSala[4].PrecioConDescuento[x, y];
                                                    contadorAdultoM++;
                                                }
                                                else if (descuento == "3")
                                                {
                                                    Console.WriteLine("Descuento: 0%");
                                                    Sala[0].peliculasSala[4].PrecioConDescuento[x, y] = (Sala[0].peliculasSala[4].PrecioTicket);
                                                    subTotal += Sala[0].peliculasSala[4].PrecioConDescuento[x, y];
                                                    contadorAdulto++;
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Opcion no valida");
                                                }

                                                //Nueva compra.
                                                Console.WriteLine();
                                                Console.WriteLine("¿Desea comprar más boletos? [Y / N: CualquierTecla]");
                                                string nuevo = Console.ReadLine();
                                                if (nuevo == "Y" || nuevo == "y")
                                                {
                                                    Compra();
                                                }
                                                else
                                                {
                                                    Factura.Add(new ResumenCompra());
                                                    Factura[Factura.Count - 1].NombrePelicula = Sala[0].peliculasSala[4].Nombre;
                                                    Factura[Factura.Count - 1].HoraFuncion = Sala[0].peliculasSala[4].Horario;
                                                    Factura[Factura.Count - 1].Sala = Sala[0].peliculasSala[4].Sala;
                                                    Factura[Factura.Count - 1].EntradasNiño = contadorNiño;
                                                    Factura[Factura.Count - 1].EntradasAdultoMayor = contadorAdultoM;
                                                    Factura[Factura.Count - 1].EntradasAdulto = contadorAdulto;
                                                    Factura[Factura.Count - 1].subTotal = subTotal;
                                                    if (Factura.Count >= 5)
                                                    {
                                                        Factura[Factura.Count - 1].Total = subTotal - (subTotal * 0.05);
                                                    }
                                                    else
                                                    {
                                                        Factura[Factura.Count - 1].Total = subTotal;
                                                    }
                                                    Console.WriteLine("Presione cualquier tecla para ir a la factura.");
                                                    Console.ReadKey();

                                                    Console.Clear();

                                                    for (int F = 0; F < Factura.Count; F++)
                                                    {
                                                        Console.WriteLine("Pelicula: " + Factura[F].NombrePelicula);
                                                        Console.WriteLine("Hora Funcion: " + Factura[F].HoraFuncion);
                                                        Console.WriteLine("Sala: " + Factura[F].Sala);
                                                        Console.WriteLine("Cantidad entradas niño: " + Factura[F].EntradasNiño);
                                                        Console.WriteLine("Cantidad entradas adulto mayor: " + Factura[F].EntradasAdultoMayor);
                                                        Console.WriteLine("Cantidad entradas adulto: " + Factura[F].EntradasAdulto);
                                                        Console.WriteLine("Cantidad entradas subtotal: " + Factura[F].subTotal);
                                                        if (contadorEntradas >= 5)
                                                        {
                                                            Console.WriteLine("Descuento por comprar mas de 5 entradas: " + (Factura[F].subTotal * 0.05));
                                                        }
                                                        Console.WriteLine("Descuento por comprar mas de 5 entradas: 0");
                                                        Console.WriteLine("Cantidad entradas total: " + Factura[F].Total);
                                                        Console.WriteLine("Hora Compra: " + DateTime.Now.ToString());

                                                    }

                                                    Console.WriteLine();
                                                    Console.WriteLine("Presione cualquier tecla para regresar al menu");
                                                    Console.ReadKey();
                                                    //Menu.
                                                    Console.Clear();
                                                    M_Principal();
                                                }

                                            }
                                            else
                                            {
                                                if (x == 7 && y == 9)
                                                {
                                                    if (Sala[0].peliculasSala[4].TablaVerdad[x, y] == false)
                                                    {
                                                        Console.WriteLine("Entrada invalida o Entrada vendida, intentelo de nuevo");
                                                        Console.ReadKey();
                                                        Compra();
                                                    }
                                                    if (Sala[0].peliculasSala[4].Asientos[x, y] != eleccion)
                                                    {
                                                        Console.WriteLine("Entrada invalida o Entrada vendida, intentelo de nuevo");
                                                        Console.ReadKey();
                                                        Compra();
                                                    }
                                                }

                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("NO HAY ASIENTOS DISPONIBLES");
                                }

                                break;

                            default:
                                Console.WriteLine("Horario no existe, intentelo de nuevo.");
                                Console.ReadKey();
                                Compra();
                                break;
                        }
                        break;

                    case "2":
                        Console.WriteLine("Ingrese la hora de inicio:");
                        switch (Console.ReadLine())
                        {
                            case "1":
                                if (RevisarAsientos(1, 0))
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("Asientos:");
                                    imprimir(Sala[1].peliculasSala[0].Asientos);
                                    string eleccion = Console.ReadLine();
                                    for (int x = 0; x < 8; x++)
                                    {
                                        for (int y = 0; y < 10; y++)
                                        {
                                            if (Sala[1].peliculasSala[0].Asientos[x, y] == eleccion && Sala[1].peliculasSala[0].TablaVerdad[x, y] == true)
                                            {
                                                Sala[1].peliculasSala[0].Asientos[x, y] = "X";
                                                Sala[1].peliculasSala[0].TablaVerdad[x, y] = false;
                                                contadorEntradas++;
                                                Console.WriteLine();
                                                Console.WriteLine("Ingrese el tipo de boleto:");
                                                Console.WriteLine("1 - Niños");
                                                Console.WriteLine("2 - Adulto Mayor");
                                                Console.WriteLine("3 - Adultos");
                                                string descuento = Console.ReadLine();
                                                if (descuento == "1")
                                                {
                                                    Console.WriteLine("Descuento: 10%");
                                                    Sala[1].peliculasSala[0].PrecioConDescuento[x, y] = (Sala[1].peliculasSala[0].PrecioTicket) - ((Sala[1].peliculasSala[0].PrecioTicket) * 0.10);
                                                    subTotal += Sala[1].peliculasSala[0].PrecioConDescuento[x, y];
                                                    contadorNiño++;

                                                }
                                                else if (descuento == "2")
                                                {
                                                    Console.WriteLine("Descuento: 20%");
                                                    Sala[1].peliculasSala[0].PrecioConDescuento[x, y] = (Sala[1].peliculasSala[0].PrecioTicket) - ((Sala[1].peliculasSala[0].PrecioTicket) * 0.20);
                                                    subTotal += Sala[1].peliculasSala[0].PrecioConDescuento[x, y];
                                                    contadorAdultoM++;
                                                }
                                                else if (descuento == "3")
                                                {
                                                    Console.WriteLine("Descuento: 0%");
                                                    Sala[1].peliculasSala[0].PrecioConDescuento[x, y] = (Sala[1].peliculasSala[0].PrecioTicket);
                                                    subTotal += Sala[1].peliculasSala[0].PrecioConDescuento[x, y];
                                                    contadorAdulto++;
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Opcion no valida");
                                                }

                                                //Nueva compra.
                                                Console.WriteLine();
                                                Console.WriteLine("¿Desea comprar más boletos? [Y / N: CualquierTecla]");
                                                string nuevo = Console.ReadLine();
                                                if (nuevo == "Y" || nuevo == "y")
                                                {
                                                    Compra();
                                                }
                                                else
                                                {
                                                    Factura.Add(new ResumenCompra());
                                                    Factura[Factura.Count - 1].NombrePelicula = Sala[1].peliculasSala[0].Nombre;
                                                    Factura[Factura.Count - 1].HoraFuncion = Sala[1].peliculasSala[0].Horario;
                                                    Factura[Factura.Count - 1].Sala = Sala[1].peliculasSala[0].Sala;
                                                    Factura[Factura.Count - 1].EntradasNiño = contadorNiño;
                                                    Factura[Factura.Count - 1].EntradasAdultoMayor = contadorAdultoM;
                                                    Factura[Factura.Count - 1].EntradasAdulto = contadorAdulto;
                                                    Factura[Factura.Count - 1].subTotal = subTotal;
                                                    if (Factura.Count >= 5)
                                                    {
                                                        Factura[Factura.Count - 1].Total = subTotal - (subTotal * 0.05);
                                                    }
                                                    else
                                                    {
                                                        Factura[Factura.Count - 1].Total = subTotal;
                                                    }
                                                    Console.WriteLine("Presione cualquier tecla para ir a la factura.");
                                                    Console.ReadKey();

                                                    Console.Clear();

                                                    for (int F = 0; F < Factura.Count; F++)
                                                    {
                                                        Console.WriteLine("Pelicula: " + Factura[F].NombrePelicula);
                                                        Console.WriteLine("Hora Funcion: " + Factura[F].HoraFuncion);
                                                        Console.WriteLine("Sala: " + Factura[F].Sala);
                                                        Console.WriteLine("Cantidad entradas niño: " + Factura[F].EntradasNiño);
                                                        Console.WriteLine("Cantidad entradas adulto mayor: " + Factura[F].EntradasAdultoMayor);
                                                        Console.WriteLine("Cantidad entradas adulto: " + Factura[F].EntradasAdulto);
                                                        Console.WriteLine("Cantidad entradas subtotal: " + Factura[F].subTotal);
                                                        if (contadorEntradas >= 5)
                                                        {
                                                            Console.WriteLine("Descuento por comprar mas de 5 entradas: " + (Factura[F].subTotal * 0.05));
                                                        }
                                                        Console.WriteLine("Descuento por comprar mas de 5 entradas: 0");
                                                        Console.WriteLine("Cantidad entradas total: " + Factura[F].Total);
                                                        Console.WriteLine("Hora Compra: " + DateTime.Now.ToString());

                                                    }

                                                    Console.WriteLine();
                                                    Console.WriteLine("Presione cualquier tecla para regresar al menu");
                                                    Console.ReadKey();
                                                    //Menu.
                                                    Console.Clear();
                                                    M_Principal();
                                                }

                                            }
                                            else
                                            {
                                                if (x == 7 && y == 9)
                                                {
                                                    if (Sala[1].peliculasSala[0].TablaVerdad[x, y] == false)
                                                    {
                                                        Console.WriteLine("Entrada invalida o Entrada vendida, intentelo de nuevo");
                                                        Console.ReadKey();
                                                        Compra();
                                                    }
                                                    if (Sala[1].peliculasSala[0].Asientos[x, y] != eleccion)
                                                    {
                                                        Console.WriteLine("Entrada invalida o Entrada vendida, intentelo de nuevo");
                                                        Console.ReadKey();
                                                        Compra();
                                                    }
                                                }

                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("NO HAY ASIENTOS DISPONIBLES");
                                }

                                break;

                            case "3":
                                if (RevisarAsientos(1, 1))
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("Asientos:");
                                    imprimir(Sala[1].peliculasSala[1].Asientos);
                                    string eleccion = Console.ReadLine();
                                    for (int x = 0; x < 8; x++)
                                    {
                                        for (int y = 0; y < 10; y++)
                                        {
                                            if (Sala[1].peliculasSala[1].Asientos[x, y] == eleccion && Sala[1].peliculasSala[1].TablaVerdad[x, y] == true)
                                            {
                                                Sala[1].peliculasSala[1].Asientos[x, y] = "X";
                                                Sala[1].peliculasSala[1].TablaVerdad[x, y] = false;
                                                contadorEntradas++;
                                                Console.WriteLine();
                                                Console.WriteLine("Ingrese el tipo de boleto:");
                                                Console.WriteLine("1 - Niños");
                                                Console.WriteLine("2 - Adulto Mayor");
                                                Console.WriteLine("3 - Adultos");
                                                string descuento = Console.ReadLine();
                                                if (descuento == "1")
                                                {
                                                    Console.WriteLine("Descuento: 10%");
                                                    Sala[1].peliculasSala[1].PrecioConDescuento[x, y] = (Sala[1].peliculasSala[1].PrecioTicket) - ((Sala[1].peliculasSala[1].PrecioTicket) * 0.10);
                                                    subTotal += Sala[1].peliculasSala[1].PrecioConDescuento[x, y];
                                                    contadorNiño++;

                                                }
                                                else if (descuento == "2")
                                                {
                                                    Console.WriteLine("Descuento: 20%");
                                                    Sala[1].peliculasSala[1].PrecioConDescuento[x, y] = (Sala[1].peliculasSala[1].PrecioTicket) - ((Sala[1].peliculasSala[1].PrecioTicket) * 0.20);
                                                    subTotal += Sala[1].peliculasSala[1].PrecioConDescuento[x, y];
                                                    contadorAdultoM++;
                                                }
                                                else if (descuento == "3")
                                                {
                                                    Console.WriteLine("Descuento: 0%");
                                                    Sala[1].peliculasSala[1].PrecioConDescuento[x, y] = (Sala[1].peliculasSala[1].PrecioTicket);
                                                    subTotal += Sala[1].peliculasSala[1].PrecioConDescuento[x, y];
                                                    contadorAdulto++;
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Opcion no valida");
                                                }

                                                //Nueva compra.
                                                Console.WriteLine();
                                                Console.WriteLine("¿Desea comprar más boletos? [Y / N: CualquierTecla]");
                                                string nuevo = Console.ReadLine();
                                                if (nuevo == "Y" || nuevo == "y")
                                                {
                                                    Compra();
                                                }
                                                else
                                                {
                                                    Factura.Add(new ResumenCompra());
                                                    Factura[Factura.Count - 1].NombrePelicula = Sala[1].peliculasSala[1].Nombre;
                                                    Factura[Factura.Count - 1].HoraFuncion = Sala[1].peliculasSala[1].Horario;
                                                    Factura[Factura.Count - 1].Sala = Sala[1].peliculasSala[1].Sala;
                                                    Factura[Factura.Count - 1].EntradasNiño = contadorNiño;
                                                    Factura[Factura.Count - 1].EntradasAdultoMayor = contadorAdultoM;
                                                    Factura[Factura.Count - 1].EntradasAdulto = contadorAdulto;
                                                    Factura[Factura.Count - 1].subTotal = subTotal;
                                                    if (Factura.Count >= 5)
                                                    {
                                                        Factura[Factura.Count - 1].Total = subTotal - (subTotal * 0.05);
                                                    }
                                                    else
                                                    {
                                                        Factura[Factura.Count - 1].Total = subTotal;
                                                    }
                                                    Console.WriteLine("Presione cualquier tecla para ir a la factura.");
                                                    Console.ReadKey();

                                                    Console.Clear();

                                                    for (int F = 0; F < Factura.Count; F++)
                                                    {
                                                        Console.WriteLine("Pelicula: " + Factura[F].NombrePelicula);
                                                        Console.WriteLine("Hora Funcion: " + Factura[F].HoraFuncion);
                                                        Console.WriteLine("Sala: " + Factura[F].Sala);
                                                        Console.WriteLine("Cantidad entradas niño: " + Factura[F].EntradasNiño);
                                                        Console.WriteLine("Cantidad entradas adulto mayor: " + Factura[F].EntradasAdultoMayor);
                                                        Console.WriteLine("Cantidad entradas adulto: " + Factura[F].EntradasAdulto);
                                                        Console.WriteLine("Cantidad entradas subtotal: " + Factura[F].subTotal);
                                                        if (contadorEntradas >= 5)
                                                        {
                                                            Console.WriteLine("Descuento por comprar mas de 5 entradas: " + (Factura[F].subTotal * 0.05));
                                                        }
                                                        Console.WriteLine("Descuento por comprar mas de 5 entradas: 0");
                                                        Console.WriteLine("Cantidad entradas total: " + Factura[F].Total);
                                                        Console.WriteLine("Hora Compra: " + DateTime.Now.ToString());

                                                    }

                                                    Console.WriteLine();
                                                    Console.WriteLine("Presione cualquier tecla para regresar al menu");
                                                    Console.ReadKey();
                                                    //Menu.
                                                    Console.Clear();
                                                    M_Principal();
                                                }

                                            }
                                            else
                                            {
                                                if (x == 7 && y == 9)
                                                {
                                                    if (Sala[1].peliculasSala[1].TablaVerdad[x, y] == false)
                                                    {
                                                        Console.WriteLine("Entrada invalida o Entrada vendida, intentelo de nuevo");
                                                        Console.ReadKey();
                                                        Compra();
                                                    }
                                                    if (Sala[1].peliculasSala[1].Asientos[x, y] != eleccion)
                                                    {
                                                        Console.WriteLine("Entrada invalida o Entrada vendida, intentelo de nuevo");
                                                        Console.ReadKey();
                                                        Compra();
                                                    }
                                                }

                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("NO HAY ASIENTOS DISPONIBLES");
                                }

                                break;

                            case "5":
                                if (RevisarAsientos(1, 2))
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("Asientos:");
                                    imprimir(Sala[1].peliculasSala[2].Asientos);
                                    string eleccion = Console.ReadLine();
                                    for (int x = 0; x < 8; x++)
                                    {
                                        for (int y = 0; y < 10; y++)
                                        {
                                            if (Sala[1].peliculasSala[2].Asientos[x, y] == eleccion && Sala[1].peliculasSala[2].TablaVerdad[x, y] == true)
                                            {
                                                Sala[1].peliculasSala[2].Asientos[x, y] = "X";
                                                Sala[1].peliculasSala[2].TablaVerdad[x, y] = false;
                                                contadorEntradas++;
                                                Console.WriteLine();
                                                Console.WriteLine("Ingrese el tipo de boleto:");
                                                Console.WriteLine("1 - Niños");
                                                Console.WriteLine("2 - Adulto Mayor");
                                                Console.WriteLine("3 - Adultos");
                                                string descuento = Console.ReadLine();
                                                if (descuento == "1")
                                                {
                                                    Console.WriteLine("Descuento: 10%");
                                                    Sala[1].peliculasSala[2].PrecioConDescuento[x, y] = (Sala[1].peliculasSala[2].PrecioTicket) - ((Sala[1].peliculasSala[2].PrecioTicket) * 0.10);
                                                    subTotal += Sala[1].peliculasSala[2].PrecioConDescuento[x, y];
                                                    contadorNiño++;

                                                }
                                                else if (descuento == "2")
                                                {
                                                    Console.WriteLine("Descuento: 20%");
                                                    Sala[1].peliculasSala[2].PrecioConDescuento[x, y] = (Sala[1].peliculasSala[2].PrecioTicket) - ((Sala[1].peliculasSala[2].PrecioTicket) * 0.20);
                                                    subTotal += Sala[1].peliculasSala[2].PrecioConDescuento[x, y];
                                                    contadorAdultoM++;
                                                }
                                                else if (descuento == "3")
                                                {
                                                    Console.WriteLine("Descuento: 0%");
                                                    Sala[1].peliculasSala[2].PrecioConDescuento[x, y] = (Sala[1].peliculasSala[2].PrecioTicket);
                                                    subTotal += Sala[1].peliculasSala[2].PrecioConDescuento[x, y];
                                                    contadorAdulto++;
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Opcion no valida");
                                                }

                                                //Nueva compra.
                                                Console.WriteLine();
                                                Console.WriteLine("¿Desea comprar más boletos? [Y / N: CualquierTecla]");
                                                string nuevo = Console.ReadLine();
                                                if (nuevo == "Y" || nuevo == "y")
                                                {
                                                    Compra();
                                                }
                                                else
                                                {
                                                    Factura.Add(new ResumenCompra());
                                                    Factura[Factura.Count - 1].NombrePelicula = Sala[1].peliculasSala[2].Nombre;
                                                    Factura[Factura.Count - 1].HoraFuncion = Sala[1].peliculasSala[2].Horario;
                                                    Factura[Factura.Count - 1].Sala = Sala[1].peliculasSala[2].Sala;
                                                    Factura[Factura.Count - 1].EntradasNiño = contadorNiño;
                                                    Factura[Factura.Count - 1].EntradasAdultoMayor = contadorAdultoM;
                                                    Factura[Factura.Count - 1].EntradasAdulto = contadorAdulto;
                                                    Factura[Factura.Count - 1].subTotal = subTotal;
                                                    if (Factura.Count >= 5)
                                                    {
                                                        Factura[Factura.Count - 1].Total = subTotal - (subTotal * 0.05);
                                                    }
                                                    else
                                                    {
                                                        Factura[Factura.Count - 1].Total = subTotal;
                                                    }
                                                    Console.WriteLine("Presione cualquier tecla para ir a la factura.");
                                                    Console.ReadKey();

                                                    Console.Clear();

                                                    for (int F = 0; F < Factura.Count; F++)
                                                    {
                                                        Console.WriteLine("Pelicula: " + Factura[F].NombrePelicula);
                                                        Console.WriteLine("Hora Funcion: " + Factura[F].HoraFuncion);
                                                        Console.WriteLine("Sala: " + Factura[F].Sala);
                                                        Console.WriteLine("Cantidad entradas niño: " + Factura[F].EntradasNiño);
                                                        Console.WriteLine("Cantidad entradas adulto mayor: " + Factura[F].EntradasAdultoMayor);
                                                        Console.WriteLine("Cantidad entradas adulto: " + Factura[F].EntradasAdulto);
                                                        Console.WriteLine("Cantidad entradas subtotal: " + Factura[F].subTotal);
                                                        if (contadorEntradas >= 5)
                                                        {
                                                            Console.WriteLine("Descuento por comprar mas de 5 entradas: " + (Factura[F].subTotal * 0.05));
                                                        }
                                                        Console.WriteLine("Descuento por comprar mas de 5 entradas: 0");
                                                        Console.WriteLine("Cantidad entradas total: " + Factura[F].Total);
                                                        Console.WriteLine("Hora Compra: " + DateTime.Now.ToString());

                                                    }

                                                    Console.WriteLine();
                                                    Console.WriteLine("Presione cualquier tecla para regresar al menu");
                                                    Console.ReadKey();
                                                    //Menu.
                                                    Console.Clear();
                                                    M_Principal();
                                                }

                                            }
                                            else
                                            {
                                                if (x == 7 && y == 9)
                                                {
                                                    if (Sala[1].peliculasSala[2].TablaVerdad[x, y] == false)
                                                    {
                                                        Console.WriteLine("Entrada invalida o Entrada vendida, intentelo de nuevo");
                                                        Console.ReadKey();
                                                        Compra();
                                                    }
                                                    if (Sala[1].peliculasSala[2].Asientos[x, y] != eleccion)
                                                    {
                                                        Console.WriteLine("Entrada invalida o Entrada vendida, intentelo de nuevo");
                                                        Console.ReadKey();
                                                        Compra();
                                                    }
                                                }

                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("NO HAY ASIENTOS DISPONIBLES");
                                }

                                break;

                            case "7":
                                if (RevisarAsientos(1, 3))
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("Asientos:");
                                    imprimir(Sala[1].peliculasSala[3].Asientos);
                                    string eleccion = Console.ReadLine();
                                    for (int x = 0; x < 8; x++)
                                    {
                                        for (int y = 0; y < 10; y++)
                                        {
                                            if (Sala[1].peliculasSala[3].Asientos[x, y] == eleccion && Sala[1].peliculasSala[3].TablaVerdad[x, y] == true)
                                            {
                                                Sala[1].peliculasSala[3].Asientos[x, y] = "X";
                                                Sala[1].peliculasSala[3].TablaVerdad[x, y] = false;
                                                contadorEntradas++;
                                                Console.WriteLine();
                                                Console.WriteLine("Ingrese el tipo de boleto:");
                                                Console.WriteLine("1 - Niños");
                                                Console.WriteLine("2 - Adulto Mayor");
                                                Console.WriteLine("3 - Adultos");
                                                string descuento = Console.ReadLine();
                                                if (descuento == "1")
                                                {
                                                    Console.WriteLine("Descuento: 10%");
                                                    Sala[1].peliculasSala[3].PrecioConDescuento[x, y] = (Sala[1].peliculasSala[3].PrecioTicket) - ((Sala[1].peliculasSala[3].PrecioTicket) * 0.10);
                                                    subTotal += Sala[1].peliculasSala[3].PrecioConDescuento[x, y];
                                                    contadorNiño++;

                                                }
                                                else if (descuento == "2")
                                                {
                                                    Console.WriteLine("Descuento: 20%");
                                                    Sala[1].peliculasSala[3].PrecioConDescuento[x, y] = (Sala[1].peliculasSala[3].PrecioTicket) - ((Sala[1].peliculasSala[3].PrecioTicket) * 0.20);
                                                    subTotal += Sala[1].peliculasSala[3].PrecioConDescuento[x, y];
                                                    contadorAdultoM++;
                                                }
                                                else if (descuento == "3")
                                                {
                                                    Console.WriteLine("Descuento: 0%");
                                                    Sala[1].peliculasSala[3].PrecioConDescuento[x, y] = (Sala[1].peliculasSala[3].PrecioTicket);
                                                    subTotal += Sala[1].peliculasSala[3].PrecioConDescuento[x, y];
                                                    contadorAdulto++;
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Opcion no valida");
                                                }

                                                //Nueva compra.
                                                Console.WriteLine();
                                                Console.WriteLine("¿Desea comprar más boletos? [Y / N: CualquierTecla]");
                                                string nuevo = Console.ReadLine();
                                                if (nuevo == "Y" || nuevo == "y")
                                                {
                                                    Compra();
                                                }
                                                else
                                                {
                                                    Factura.Add(new ResumenCompra());
                                                    Factura[Factura.Count - 1].NombrePelicula = Sala[1].peliculasSala[3].Nombre;
                                                    Factura[Factura.Count - 1].HoraFuncion = Sala[1].peliculasSala[3].Horario;
                                                    Factura[Factura.Count - 1].Sala = Sala[1].peliculasSala[3].Sala;
                                                    Factura[Factura.Count - 1].EntradasNiño = contadorNiño;
                                                    Factura[Factura.Count - 1].EntradasAdultoMayor = contadorAdultoM;
                                                    Factura[Factura.Count - 1].EntradasAdulto = contadorAdulto;
                                                    Factura[Factura.Count - 1].subTotal = subTotal;
                                                    if (Factura.Count >= 5)
                                                    {
                                                        Factura[Factura.Count - 1].Total = subTotal - (subTotal * 0.05);
                                                    }
                                                    else
                                                    {
                                                        Factura[Factura.Count - 1].Total = subTotal;
                                                    }
                                                    Console.WriteLine("Presione cualquier tecla para ir a la factura.");
                                                    Console.ReadKey();

                                                    Console.Clear();

                                                    for (int F = 0; F < Factura.Count; F++)
                                                    {
                                                        Console.WriteLine("Pelicula: " + Factura[F].NombrePelicula);
                                                        Console.WriteLine("Hora Funcion: " + Factura[F].HoraFuncion);
                                                        Console.WriteLine("Sala: " + Factura[F].Sala);
                                                        Console.WriteLine("Cantidad entradas niño: " + Factura[F].EntradasNiño);
                                                        Console.WriteLine("Cantidad entradas adulto mayor: " + Factura[F].EntradasAdultoMayor);
                                                        Console.WriteLine("Cantidad entradas adulto: " + Factura[F].EntradasAdulto);
                                                        Console.WriteLine("Cantidad entradas subtotal: " + Factura[F].subTotal);
                                                        if (contadorEntradas >= 5)
                                                        {
                                                            Console.WriteLine("Descuento por comprar mas de 5 entradas: " + (Factura[F].subTotal * 0.05));
                                                        }
                                                        Console.WriteLine("Descuento por comprar mas de 5 entradas: 0");
                                                        Console.WriteLine("Cantidad entradas total: " + Factura[F].Total);
                                                        Console.WriteLine("Hora Compra: " + DateTime.Now.ToString());

                                                    }

                                                    Console.WriteLine();
                                                    Console.WriteLine("Presione cualquier tecla para regresar al menu");
                                                    Console.ReadKey();
                                                    //Menu.
                                                    Console.Clear();
                                                    M_Principal();
                                                }

                                            }
                                            else
                                            {
                                                if (x == 7 && y == 9)
                                                {
                                                    if (Sala[1].peliculasSala[3].TablaVerdad[x, y] == false)
                                                    {
                                                        Console.WriteLine("Entrada invalida o Entrada vendida, intentelo de nuevo");
                                                        Console.ReadKey();
                                                        Compra();
                                                    }
                                                    if (Sala[1].peliculasSala[3].Asientos[x, y] != eleccion)
                                                    {
                                                        Console.WriteLine("Entrada invalida o Entrada vendida, intentelo de nuevo");
                                                        Console.ReadKey();
                                                        Compra();
                                                    }
                                                }

                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("NO HAY ASIENTOS DISPONIBLES");
                                }

                                break;

                            case "9":
                                if (RevisarAsientos(1, 4))
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("Asientos:");
                                    imprimir(Sala[1].peliculasSala[4].Asientos);
                                    string eleccion = Console.ReadLine();
                                    for (int x = 0; x < 8; x++)
                                    {
                                        for (int y = 0; y < 10; y++)
                                        {
                                            if (Sala[1].peliculasSala[4].Asientos[x, y] == eleccion && Sala[1].peliculasSala[4].TablaVerdad[x, y] == true)
                                            {
                                                Sala[1].peliculasSala[4].Asientos[x, y] = "X";
                                                Sala[1].peliculasSala[4].TablaVerdad[x, y] = false;
                                                contadorEntradas++;
                                                Console.WriteLine();
                                                Console.WriteLine("Ingrese el tipo de boleto:");
                                                Console.WriteLine("1 - Niños");
                                                Console.WriteLine("2 - Adulto Mayor");
                                                Console.WriteLine("3 - Adultos");
                                                string descuento = Console.ReadLine();
                                                if (descuento == "1")
                                                {
                                                    Console.WriteLine("Descuento: 10%");
                                                    Sala[1].peliculasSala[4].PrecioConDescuento[x, y] = (Sala[1].peliculasSala[4].PrecioTicket) - ((Sala[1].peliculasSala[4].PrecioTicket) * 0.10);
                                                    subTotal += Sala[1].peliculasSala[4].PrecioConDescuento[x, y];
                                                    contadorNiño++;

                                                }
                                                else if (descuento == "2")
                                                {
                                                    Console.WriteLine("Descuento: 20%");
                                                    Sala[1].peliculasSala[4].PrecioConDescuento[x, y] = (Sala[1].peliculasSala[4].PrecioTicket) - ((Sala[1].peliculasSala[4].PrecioTicket) * 0.20);
                                                    subTotal += Sala[1].peliculasSala[4].PrecioConDescuento[x, y];
                                                    contadorAdultoM++;
                                                }
                                                else if (descuento == "3")
                                                {
                                                    Console.WriteLine("Descuento: 0%");
                                                    Sala[1].peliculasSala[4].PrecioConDescuento[x, y] = (Sala[1].peliculasSala[4].PrecioTicket);
                                                    subTotal += Sala[1].peliculasSala[4].PrecioConDescuento[x, y];
                                                    contadorAdulto++;
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Opcion no valida");
                                                }

                                                //Nueva compra.
                                                Console.WriteLine();
                                                Console.WriteLine("¿Desea comprar más boletos? [Y / N: CualquierTecla]");
                                                string nuevo = Console.ReadLine();
                                                if (nuevo == "Y" || nuevo == "y")
                                                {
                                                    Compra();
                                                }
                                                else
                                                {
                                                    Factura.Add(new ResumenCompra());
                                                    Factura[Factura.Count - 1].NombrePelicula = Sala[1].peliculasSala[4].Nombre;
                                                    Factura[Factura.Count - 1].HoraFuncion = Sala[1].peliculasSala[4].Horario;
                                                    Factura[Factura.Count - 1].Sala = Sala[1].peliculasSala[4].Sala;
                                                    Factura[Factura.Count - 1].EntradasNiño = contadorNiño;
                                                    Factura[Factura.Count - 1].EntradasAdultoMayor = contadorAdultoM;
                                                    Factura[Factura.Count - 1].EntradasAdulto = contadorAdulto;
                                                    Factura[Factura.Count - 1].subTotal = subTotal;
                                                    if (Factura.Count >= 5)
                                                    {
                                                        Factura[Factura.Count - 1].Total = subTotal - (subTotal * 0.05);
                                                    }
                                                    else
                                                    {
                                                        Factura[Factura.Count - 1].Total = subTotal;
                                                    }
                                                    Console.WriteLine("Presione cualquier tecla para ir a la factura.");
                                                    Console.ReadKey();

                                                    Console.Clear();

                                                    for (int F = 0; F < Factura.Count; F++)
                                                    {
                                                        Console.WriteLine("Pelicula: " + Factura[F].NombrePelicula);
                                                        Console.WriteLine("Hora Funcion: " + Factura[F].HoraFuncion);
                                                        Console.WriteLine("Sala: " + Factura[F].Sala);
                                                        Console.WriteLine("Cantidad entradas niño: " + Factura[F].EntradasNiño);
                                                        Console.WriteLine("Cantidad entradas adulto mayor: " + Factura[F].EntradasAdultoMayor);
                                                        Console.WriteLine("Cantidad entradas adulto: " + Factura[F].EntradasAdulto);
                                                        Console.WriteLine("Cantidad entradas subtotal: " + Factura[F].subTotal);
                                                        if (contadorEntradas >= 5)
                                                        {
                                                            Console.WriteLine("Descuento por comprar mas de 5 entradas: " + (Factura[F].subTotal * 0.05));
                                                        }
                                                        Console.WriteLine("Descuento por comprar mas de 5 entradas: 0");
                                                        Console.WriteLine("Cantidad entradas total: " + Factura[F].Total);
                                                        Console.WriteLine("Hora Compra: " + DateTime.Now.ToString());

                                                    }

                                                    Console.WriteLine();
                                                    Console.WriteLine("Presione cualquier tecla para regresar al menu");
                                                    Console.ReadKey();
                                                    //Menu.
                                                    Console.Clear();
                                                    M_Principal();
                                                }

                                            }
                                            else
                                            {
                                                if (x == 7 && y == 9)
                                                {
                                                    if (Sala[1].peliculasSala[4].TablaVerdad[x, y] == false)
                                                    {
                                                        Console.WriteLine("Entrada invalida o Entrada vendida, intentelo de nuevo");
                                                        Console.ReadKey();
                                                        Compra();
                                                    }
                                                    if (Sala[1].peliculasSala[4].Asientos[x, y] != eleccion)
                                                    {
                                                        Console.WriteLine("Entrada invalida o Entrada vendida, intentelo de nuevo");
                                                        Console.ReadKey();
                                                        Compra();
                                                    }
                                                }

                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("NO HAY ASIENTOS DISPONIBLES");
                                }

                                break;
                                
                            default:
                                Console.WriteLine("Horario no existe, intentelo de nuevo.");
                                Console.ReadKey();
                                Compra();
                                break;
                        }
                        break;

                    case "3":
                        Console.WriteLine("Ingrese la hora de inicio:");
                        switch (Console.ReadLine())
                        {
                            case "1":
                                if (RevisarAsientos(2, 0))
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("Asientos:");
                                    imprimir(Sala[2].peliculasSala[0].Asientos);
                                    string eleccion = Console.ReadLine();
                                    for (int x = 0; x < 8; x++)
                                    {
                                        for (int y = 0; y < 10; y++)
                                        {
                                            if (Sala[2].peliculasSala[0].Asientos[x, y] == eleccion && Sala[2].peliculasSala[0].TablaVerdad[x, y] == true)
                                            {
                                                Sala[2].peliculasSala[0].Asientos[x, y] = "X";
                                                Sala[2].peliculasSala[0].TablaVerdad[x, y] = false;
                                                contadorEntradas++;
                                                Console.WriteLine();
                                                Console.WriteLine("Ingrese el tipo de boleto:");
                                                Console.WriteLine("1 - Niños");
                                                Console.WriteLine("2 - Adulto Mayor");
                                                Console.WriteLine("3 - Adultos");
                                                string descuento = Console.ReadLine();
                                                if (descuento == "1")
                                                {
                                                    Console.WriteLine("Descuento: 10%");
                                                    Sala[2].peliculasSala[0].PrecioConDescuento[x, y] = (Sala[2].peliculasSala[0].PrecioTicket) - ((Sala[2].peliculasSala[0].PrecioTicket) * 0.10);
                                                    subTotal += Sala[2].peliculasSala[0].PrecioConDescuento[x, y];
                                                    contadorNiño++;

                                                }
                                                else if (descuento == "2")
                                                {
                                                    Console.WriteLine("Descuento: 20%");
                                                    Sala[2].peliculasSala[0].PrecioConDescuento[x, y] = (Sala[2].peliculasSala[0].PrecioTicket) - ((Sala[2].peliculasSala[0].PrecioTicket) * 0.20);
                                                    subTotal += Sala[2].peliculasSala[0].PrecioConDescuento[x, y];
                                                    contadorAdultoM++;
                                                }
                                                else if (descuento == "3")
                                                {
                                                    Console.WriteLine("Descuento: 0%");
                                                    Sala[2].peliculasSala[0].PrecioConDescuento[x, y] = (Sala[2].peliculasSala[0].PrecioTicket);
                                                    subTotal += Sala[2].peliculasSala[0].PrecioConDescuento[x, y];
                                                    contadorAdulto++;
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Opcion no valida");
                                                }

                                                //Nueva compra.
                                                Console.WriteLine();
                                                Console.WriteLine("¿Desea comprar más boletos? [Y / N: CualquierTecla]");
                                                string nuevo = Console.ReadLine();
                                                if (nuevo == "Y" || nuevo == "y")
                                                {
                                                    Compra();
                                                }
                                                else
                                                {
                                                    Factura.Add(new ResumenCompra());
                                                    Factura[Factura.Count - 1].NombrePelicula = Sala[2].peliculasSala[0].Nombre;
                                                    Factura[Factura.Count - 1].HoraFuncion = Sala[2].peliculasSala[0].Horario;
                                                    Factura[Factura.Count - 1].Sala = Sala[2].peliculasSala[0].Sala;
                                                    Factura[Factura.Count - 1].EntradasNiño = contadorNiño;
                                                    Factura[Factura.Count - 1].EntradasAdultoMayor = contadorAdultoM;
                                                    Factura[Factura.Count - 1].EntradasAdulto = contadorAdulto;
                                                    Factura[Factura.Count - 1].subTotal = subTotal;
                                                    if (Factura.Count >= 5)
                                                    {
                                                        Factura[Factura.Count - 1].Total = subTotal - (subTotal * 0.05);
                                                    }
                                                    else
                                                    {
                                                        Factura[Factura.Count - 1].Total = subTotal;
                                                    }
                                                    Console.WriteLine("Presione cualquier tecla para ir a la factura.");
                                                    Console.ReadKey();

                                                    Console.Clear();

                                                    for (int F = 0; F < Factura.Count; F++)
                                                    {
                                                        Console.WriteLine("Pelicula: " + Factura[F].NombrePelicula);
                                                        Console.WriteLine("Hora Funcion: " + Factura[F].HoraFuncion);
                                                        Console.WriteLine("Sala: " + Factura[F].Sala);
                                                        Console.WriteLine("Cantidad entradas niño: " + Factura[F].EntradasNiño);
                                                        Console.WriteLine("Cantidad entradas adulto mayor: " + Factura[F].EntradasAdultoMayor);
                                                        Console.WriteLine("Cantidad entradas adulto: " + Factura[F].EntradasAdulto);
                                                        Console.WriteLine("Cantidad entradas subtotal: " + Factura[F].subTotal);
                                                        if (contadorEntradas >= 5)
                                                        {
                                                            Console.WriteLine("Descuento por comprar mas de 5 entradas: " + (Factura[F].subTotal * 0.05));
                                                        }
                                                        Console.WriteLine("Descuento por comprar mas de 5 entradas: 0");
                                                        Console.WriteLine("Cantidad entradas total: " + Factura[F].Total);
                                                        Console.WriteLine("Hora Compra: " + DateTime.Now.ToString());

                                                    }

                                                    Console.WriteLine();
                                                    Console.WriteLine("Presione cualquier tecla para regresar al menu");
                                                    Console.ReadKey();
                                                    //Menu.
                                                    Console.Clear();
                                                    M_Principal();
                                                }

                                            }
                                            else
                                            {
                                                if (x == 7 && y == 9)
                                                {
                                                    if (Sala[2].peliculasSala[0].TablaVerdad[x, y] == false)
                                                    {
                                                        Console.WriteLine("Entrada invalida o Entrada vendida, intentelo de nuevo");
                                                        Console.ReadKey();
                                                        Compra();
                                                    }
                                                    if (Sala[2].peliculasSala[0].Asientos[x, y] != eleccion)
                                                    {
                                                        Console.WriteLine("Entrada invalida o Entrada vendida, intentelo de nuevo");
                                                        Console.ReadKey();
                                                        Compra();
                                                    }
                                                }

                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("NO HAY ASIENTOS DISPONIBLES");
                                }

                                break;

                            case "3":
                                if (RevisarAsientos(2, 1))
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("Asientos:");
                                    imprimir(Sala[2].peliculasSala[1].Asientos);
                                    string eleccion = Console.ReadLine();
                                    for (int x = 0; x < 8; x++)
                                    {
                                        for (int y = 0; y < 10; y++)
                                        {
                                            if (Sala[2].peliculasSala[1].Asientos[x, y] == eleccion && Sala[2].peliculasSala[1].TablaVerdad[x, y] == true)
                                            {
                                                Sala[2].peliculasSala[1].Asientos[x, y] = "X";
                                                Sala[2].peliculasSala[1].TablaVerdad[x, y] = false;
                                                contadorEntradas++;
                                                Console.WriteLine();
                                                Console.WriteLine("Ingrese el tipo de boleto:");
                                                Console.WriteLine("1 - Niños");
                                                Console.WriteLine("2 - Adulto Mayor");
                                                Console.WriteLine("3 - Adultos");
                                                string descuento = Console.ReadLine();
                                                if (descuento == "1")
                                                {
                                                    Console.WriteLine("Descuento: 10%");
                                                    Sala[2].peliculasSala[1].PrecioConDescuento[x, y] = (Sala[2].peliculasSala[1].PrecioTicket) - ((Sala[2].peliculasSala[1].PrecioTicket) * 0.10);
                                                    subTotal += Sala[2].peliculasSala[1].PrecioConDescuento[x, y];
                                                    contadorNiño++;

                                                }
                                                else if (descuento == "2")
                                                {
                                                    Console.WriteLine("Descuento: 20%");
                                                    Sala[2].peliculasSala[1].PrecioConDescuento[x, y] = (Sala[2].peliculasSala[1].PrecioTicket) - ((Sala[2].peliculasSala[1].PrecioTicket) * 0.20);
                                                    subTotal += Sala[2].peliculasSala[1].PrecioConDescuento[x, y];
                                                    contadorAdultoM++;
                                                }
                                                else if (descuento == "3")
                                                {
                                                    Console.WriteLine("Descuento: 0%");
                                                    Sala[2].peliculasSala[1].PrecioConDescuento[x, y] = (Sala[2].peliculasSala[1].PrecioTicket);
                                                    subTotal += Sala[2].peliculasSala[1].PrecioConDescuento[x, y];
                                                    contadorAdulto++;
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Opcion no valida");
                                                }

                                                //Nueva compra.
                                                Console.WriteLine();
                                                Console.WriteLine("¿Desea comprar más boletos? [Y / N: CualquierTecla]");
                                                string nuevo = Console.ReadLine();
                                                if (nuevo == "Y" || nuevo == "y")
                                                {
                                                    Compra();
                                                }
                                                else
                                                {
                                                    Factura.Add(new ResumenCompra());
                                                    Factura[Factura.Count - 1].NombrePelicula = Sala[2].peliculasSala[1].Nombre;
                                                    Factura[Factura.Count - 1].HoraFuncion = Sala[2].peliculasSala[1].Horario;
                                                    Factura[Factura.Count - 1].Sala = Sala[2].peliculasSala[1].Sala;
                                                    Factura[Factura.Count - 1].EntradasNiño = contadorNiño;
                                                    Factura[Factura.Count - 1].EntradasAdultoMayor = contadorAdultoM;
                                                    Factura[Factura.Count - 1].EntradasAdulto = contadorAdulto;
                                                    Factura[Factura.Count - 1].subTotal = subTotal;
                                                    if (Factura.Count >= 5)
                                                    {
                                                        Factura[Factura.Count - 1].Total = subTotal - (subTotal * 0.05);
                                                    }
                                                    else
                                                    {
                                                        Factura[Factura.Count - 1].Total = subTotal;
                                                    }
                                                    Console.WriteLine("Presione cualquier tecla para ir a la factura.");
                                                    Console.ReadKey();

                                                    Console.Clear();

                                                    for (int F = 0; F < Factura.Count; F++)
                                                    {
                                                        Console.WriteLine("Pelicula: " + Factura[F].NombrePelicula);
                                                        Console.WriteLine("Hora Funcion: " + Factura[F].HoraFuncion);
                                                        Console.WriteLine("Sala: " + Factura[F].Sala);
                                                        Console.WriteLine("Cantidad entradas niño: " + Factura[F].EntradasNiño);
                                                        Console.WriteLine("Cantidad entradas adulto mayor: " + Factura[F].EntradasAdultoMayor);
                                                        Console.WriteLine("Cantidad entradas adulto: " + Factura[F].EntradasAdulto);
                                                        Console.WriteLine("Cantidad entradas subtotal: " + Factura[F].subTotal);
                                                        if (contadorEntradas >= 5)
                                                        {
                                                            Console.WriteLine("Descuento por comprar mas de 5 entradas: " + (Factura[F].subTotal * 0.05));
                                                        }
                                                        Console.WriteLine("Descuento por comprar mas de 5 entradas: 0");
                                                        Console.WriteLine("Cantidad entradas total: " + Factura[F].Total);
                                                        Console.WriteLine("Hora Compra: " + DateTime.Now.ToString());

                                                    }

                                                    Console.WriteLine();
                                                    Console.WriteLine("Presione cualquier tecla para regresar al menu");
                                                    Console.ReadKey();
                                                    //Menu.
                                                    Console.Clear();
                                                    M_Principal();
                                                }

                                            }
                                            else
                                            {
                                                if (x == 7 && y == 9)
                                                {
                                                    if (Sala[2].peliculasSala[1].TablaVerdad[x, y] == false)
                                                    {
                                                        Console.WriteLine("Entrada invalida o Entrada vendida, intentelo de nuevo");
                                                        Console.ReadKey();
                                                        Compra();
                                                    }
                                                    if (Sala[2].peliculasSala[1].Asientos[x, y] != eleccion)
                                                    {
                                                        Console.WriteLine("Entrada invalida o Entrada vendida, intentelo de nuevo");
                                                        Console.ReadKey();
                                                        Compra();
                                                    }
                                                }

                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("NO HAY ASIENTOS DISPONIBLES");
                                }

                                break;

                            case "5":
                                if (RevisarAsientos(2, 2))
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("Asientos:");
                                    imprimir(Sala[2].peliculasSala[2].Asientos);
                                    string eleccion = Console.ReadLine();
                                    for (int x = 0; x < 8; x++)
                                    {
                                        for (int y = 0; y < 10; y++)
                                        {
                                            if (Sala[2].peliculasSala[2].Asientos[x, y] == eleccion && Sala[2].peliculasSala[2].TablaVerdad[x, y] == true)
                                            {
                                                Sala[2].peliculasSala[2].Asientos[x, y] = "X";
                                                Sala[2].peliculasSala[2].TablaVerdad[x, y] = false;
                                                contadorEntradas++;
                                                Console.WriteLine();
                                                Console.WriteLine("Ingrese el tipo de boleto:");
                                                Console.WriteLine("1 - Niños");
                                                Console.WriteLine("2 - Adulto Mayor");
                                                Console.WriteLine("3 - Adultos");
                                                string descuento = Console.ReadLine();
                                                if (descuento == "1")
                                                {
                                                    Console.WriteLine("Descuento: 10%");
                                                    Sala[2].peliculasSala[2].PrecioConDescuento[x, y] = (Sala[2].peliculasSala[2].PrecioTicket) - ((Sala[2].peliculasSala[2].PrecioTicket) * 0.10);
                                                    subTotal += Sala[2].peliculasSala[2].PrecioConDescuento[x, y];
                                                    contadorNiño++;

                                                }
                                                else if (descuento == "2")
                                                {
                                                    Console.WriteLine("Descuento: 20%");
                                                    Sala[2].peliculasSala[2].PrecioConDescuento[x, y] = (Sala[2].peliculasSala[2].PrecioTicket) - ((Sala[2].peliculasSala[2].PrecioTicket) * 0.20);
                                                    subTotal += Sala[2].peliculasSala[2].PrecioConDescuento[x, y];
                                                    contadorAdultoM++;
                                                }
                                                else if (descuento == "3")
                                                {
                                                    Console.WriteLine("Descuento: 0%");
                                                    Sala[2].peliculasSala[2].PrecioConDescuento[x, y] = (Sala[2].peliculasSala[2].PrecioTicket);
                                                    subTotal += Sala[2].peliculasSala[2].PrecioConDescuento[x, y];
                                                    contadorAdulto++;
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Opcion no valida");
                                                }

                                                //Nueva compra.
                                                Console.WriteLine();
                                                Console.WriteLine("¿Desea comprar más boletos? [Y / N: CualquierTecla]");
                                                string nuevo = Console.ReadLine();
                                                if (nuevo == "Y" || nuevo == "y")
                                                {
                                                    Compra();
                                                }
                                                else
                                                {
                                                    Factura.Add(new ResumenCompra());
                                                    Factura[Factura.Count - 1].NombrePelicula = Sala[2].peliculasSala[2].Nombre;
                                                    Factura[Factura.Count - 1].HoraFuncion = Sala[2].peliculasSala[2].Horario;
                                                    Factura[Factura.Count - 1].Sala = Sala[2].peliculasSala[2].Sala;
                                                    Factura[Factura.Count - 1].EntradasNiño = contadorNiño;
                                                    Factura[Factura.Count - 1].EntradasAdultoMayor = contadorAdultoM;
                                                    Factura[Factura.Count - 1].EntradasAdulto = contadorAdulto;
                                                    Factura[Factura.Count - 1].subTotal = subTotal;
                                                    if (Factura.Count >= 5)
                                                    {
                                                        Factura[Factura.Count - 1].Total = subTotal - (subTotal * 0.05);
                                                    }
                                                    else
                                                    {
                                                        Factura[Factura.Count - 1].Total = subTotal;
                                                    }
                                                    Console.WriteLine("Presione cualquier tecla para ir a la factura.");
                                                    Console.ReadKey();

                                                    Console.Clear();

                                                    for (int F = 0; F < Factura.Count; F++)
                                                    {
                                                        Console.WriteLine("Pelicula: " + Factura[F].NombrePelicula);
                                                        Console.WriteLine("Hora Funcion: " + Factura[F].HoraFuncion);
                                                        Console.WriteLine("Sala: " + Factura[F].Sala);
                                                        Console.WriteLine("Cantidad entradas niño: " + Factura[F].EntradasNiño);
                                                        Console.WriteLine("Cantidad entradas adulto mayor: " + Factura[F].EntradasAdultoMayor);
                                                        Console.WriteLine("Cantidad entradas adulto: " + Factura[F].EntradasAdulto);
                                                        Console.WriteLine("Cantidad entradas subtotal: " + Factura[F].subTotal);
                                                        if (contadorEntradas >= 5)
                                                        {
                                                            Console.WriteLine("Descuento por comprar mas de 5 entradas: " + (Factura[F].subTotal * 0.05));
                                                        }
                                                        Console.WriteLine("Descuento por comprar mas de 5 entradas: 0");
                                                        Console.WriteLine("Cantidad entradas total: " + Factura[F].Total);
                                                        Console.WriteLine("Hora Compra: " + DateTime.Now.ToString());

                                                    }

                                                    Console.WriteLine();
                                                    Console.WriteLine("Presione cualquier tecla para regresar al menu");
                                                    Console.ReadKey();
                                                    //Menu.
                                                    Console.Clear();
                                                    M_Principal();
                                                }

                                            }
                                            else
                                            {
                                                if (x == 7 && y == 9)
                                                {
                                                    if (Sala[2].peliculasSala[2].TablaVerdad[x, y] == false)
                                                    {
                                                        Console.WriteLine("Entrada invalida o Entrada vendida, intentelo de nuevo");
                                                        Console.ReadKey();
                                                        Compra();
                                                    }
                                                    if (Sala[2].peliculasSala[2].Asientos[x, y] != eleccion)
                                                    {
                                                        Console.WriteLine("Entrada invalida o Entrada vendida, intentelo de nuevo");
                                                        Console.ReadKey();
                                                        Compra();
                                                    }
                                                }

                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("NO HAY ASIENTOS DISPONIBLES");
                                }

                                break;

                            case "7":
                                if (RevisarAsientos(2, 3))
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("Asientos:");
                                    imprimir(Sala[2].peliculasSala[3].Asientos);
                                    string eleccion = Console.ReadLine();
                                    for (int x = 0; x < 8; x++)
                                    {
                                        for (int y = 0; y < 10; y++)
                                        {
                                            if (Sala[2].peliculasSala[3].Asientos[x, y] == eleccion && Sala[2].peliculasSala[3].TablaVerdad[x, y] == true)
                                            {
                                                Sala[2].peliculasSala[3].Asientos[x, y] = "X";
                                                Sala[2].peliculasSala[3].TablaVerdad[x, y] = false;
                                                contadorEntradas++;
                                                Console.WriteLine();
                                                Console.WriteLine("Ingrese el tipo de boleto:");
                                                Console.WriteLine("1 - Niños");
                                                Console.WriteLine("2 - Adulto Mayor");
                                                Console.WriteLine("3 - Adultos");
                                                string descuento = Console.ReadLine();
                                                if (descuento == "1")
                                                {
                                                    Console.WriteLine("Descuento: 10%");
                                                    Sala[2].peliculasSala[3].PrecioConDescuento[x, y] = (Sala[2].peliculasSala[3].PrecioTicket) - ((Sala[2].peliculasSala[3].PrecioTicket) * 0.10);
                                                    subTotal += Sala[2].peliculasSala[3].PrecioConDescuento[x, y];
                                                    contadorNiño++;

                                                }
                                                else if (descuento == "2")
                                                {
                                                    Console.WriteLine("Descuento: 20%");
                                                    Sala[2].peliculasSala[3].PrecioConDescuento[x, y] = (Sala[2].peliculasSala[3].PrecioTicket) - ((Sala[2].peliculasSala[3].PrecioTicket) * 0.20);
                                                    subTotal += Sala[2].peliculasSala[3].PrecioConDescuento[x, y];
                                                    contadorAdultoM++;
                                                }
                                                else if (descuento == "3")
                                                {
                                                    Console.WriteLine("Descuento: 0%");
                                                    Sala[2].peliculasSala[3].PrecioConDescuento[x, y] = (Sala[2].peliculasSala[3].PrecioTicket);
                                                    subTotal += Sala[2].peliculasSala[3].PrecioConDescuento[x, y];
                                                    contadorAdulto++;
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Opcion no valida");
                                                }

                                                //Nueva compra.
                                                Console.WriteLine();
                                                Console.WriteLine("¿Desea comprar más boletos? [Y / N: CualquierTecla]");
                                                string nuevo = Console.ReadLine();
                                                if (nuevo == "Y" || nuevo == "y")
                                                {
                                                    Compra();
                                                }
                                                else
                                                {
                                                    Factura.Add(new ResumenCompra());
                                                    Factura[Factura.Count - 1].NombrePelicula = Sala[2].peliculasSala[3].Nombre;
                                                    Factura[Factura.Count - 1].HoraFuncion = Sala[2].peliculasSala[3].Horario;
                                                    Factura[Factura.Count - 1].Sala = Sala[2].peliculasSala[3].Sala;
                                                    Factura[Factura.Count - 1].EntradasNiño = contadorNiño;
                                                    Factura[Factura.Count - 1].EntradasAdultoMayor = contadorAdultoM;
                                                    Factura[Factura.Count - 1].EntradasAdulto = contadorAdulto;
                                                    Factura[Factura.Count - 1].subTotal = subTotal;
                                                    if (Factura.Count >= 5)
                                                    {
                                                        Factura[Factura.Count - 1].Total = subTotal - (subTotal * 0.05);
                                                    }
                                                    else
                                                    {
                                                        Factura[Factura.Count - 1].Total = subTotal;
                                                    }
                                                    Console.WriteLine("Presione cualquier tecla para ir a la factura.");
                                                    Console.ReadKey();

                                                    Console.Clear();

                                                    for (int F = 0; F < Factura.Count; F++)
                                                    {
                                                        Console.WriteLine("Pelicula: " + Factura[F].NombrePelicula);
                                                        Console.WriteLine("Hora Funcion: " + Factura[F].HoraFuncion);
                                                        Console.WriteLine("Sala: " + Factura[F].Sala);
                                                        Console.WriteLine("Cantidad entradas niño: " + Factura[F].EntradasNiño);
                                                        Console.WriteLine("Cantidad entradas adulto mayor: " + Factura[F].EntradasAdultoMayor);
                                                        Console.WriteLine("Cantidad entradas adulto: " + Factura[F].EntradasAdulto);
                                                        Console.WriteLine("Cantidad entradas subtotal: " + Factura[F].subTotal);
                                                        if (contadorEntradas >= 5)
                                                        {
                                                            Console.WriteLine("Descuento por comprar mas de 5 entradas: " + (Factura[F].subTotal * 0.05));
                                                        }
                                                        Console.WriteLine("Descuento por comprar mas de 5 entradas: 0");
                                                        Console.WriteLine("Cantidad entradas total: " + Factura[F].Total);
                                                        Console.WriteLine("Hora Compra: " + DateTime.Now.ToString());

                                                    }

                                                    Console.WriteLine();
                                                    Console.WriteLine("Presione cualquier tecla para regresar al menu");
                                                    Console.ReadKey();
                                                    //Menu.
                                                    Console.Clear();
                                                    M_Principal();
                                                }

                                            }
                                            else
                                            {
                                                if (x == 7 && y == 9)
                                                {
                                                    if (Sala[2].peliculasSala[3].TablaVerdad[x, y] == false)
                                                    {
                                                        Console.WriteLine("Entrada invalida o Entrada vendida, intentelo de nuevo");
                                                        Console.ReadKey();
                                                        Compra();
                                                    }
                                                    if (Sala[2].peliculasSala[3].Asientos[x, y] != eleccion)
                                                    {
                                                        Console.WriteLine("Entrada invalida o Entrada vendida, intentelo de nuevo");
                                                        Console.ReadKey();
                                                        Compra();
                                                    }
                                                }

                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("NO HAY ASIENTOS DISPONIBLES");
                                }

                                break;

                            case "9":
                                if (RevisarAsientos(2, 4))
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("Asientos:");
                                    imprimir(Sala[2].peliculasSala[4].Asientos);
                                    string eleccion = Console.ReadLine();
                                    for (int x = 0; x < 8; x++)
                                    {
                                        for (int y = 0; y < 10; y++)
                                        {
                                            if (Sala[2].peliculasSala[4].Asientos[x, y] == eleccion && Sala[2].peliculasSala[4].TablaVerdad[x, y] == true)
                                            {
                                                Sala[2].peliculasSala[4].Asientos[x, y] = "X";
                                                Sala[2].peliculasSala[4].TablaVerdad[x, y] = false;
                                                contadorEntradas++;
                                                Console.WriteLine();
                                                Console.WriteLine("Ingrese el tipo de boleto:");
                                                Console.WriteLine("1 - Niños");
                                                Console.WriteLine("2 - Adulto Mayor");
                                                Console.WriteLine("3 - Adultos");
                                                string descuento = Console.ReadLine();
                                                if (descuento == "1")
                                                {
                                                    Console.WriteLine("Descuento: 10%");
                                                    Sala[2].peliculasSala[4].PrecioConDescuento[x, y] = (Sala[2].peliculasSala[4].PrecioTicket) - ((Sala[2].peliculasSala[4].PrecioTicket) * 0.10);
                                                    subTotal += Sala[2].peliculasSala[4].PrecioConDescuento[x, y];
                                                    contadorNiño++;

                                                }
                                                else if (descuento == "2")
                                                {
                                                    Console.WriteLine("Descuento: 20%");
                                                    Sala[2].peliculasSala[4].PrecioConDescuento[x, y] = (Sala[2].peliculasSala[4].PrecioTicket) - ((Sala[2].peliculasSala[4].PrecioTicket) * 0.20);
                                                    subTotal += Sala[2].peliculasSala[4].PrecioConDescuento[x, y];
                                                    contadorAdultoM++;
                                                }
                                                else if (descuento == "3")
                                                {
                                                    Console.WriteLine("Descuento: 0%");
                                                    Sala[2].peliculasSala[4].PrecioConDescuento[x, y] = (Sala[2].peliculasSala[4].PrecioTicket);
                                                    subTotal += Sala[2].peliculasSala[4].PrecioConDescuento[x, y];
                                                    contadorAdulto++;
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Opcion no valida");
                                                }

                                                //Nueva compra.
                                                Console.WriteLine();
                                                Console.WriteLine("¿Desea comprar más boletos? [Y / N: CualquierTecla]");
                                                string nuevo = Console.ReadLine();
                                                if (nuevo == "Y" || nuevo == "y")
                                                {
                                                    Compra();
                                                }
                                                else
                                                {
                                                    Factura.Add(new ResumenCompra());
                                                    Factura[Factura.Count - 1].NombrePelicula = Sala[2].peliculasSala[4].Nombre;
                                                    Factura[Factura.Count - 1].HoraFuncion = Sala[2].peliculasSala[4].Horario;
                                                    Factura[Factura.Count - 1].Sala = Sala[2].peliculasSala[4].Sala;
                                                    Factura[Factura.Count - 1].EntradasNiño = contadorNiño;
                                                    Factura[Factura.Count - 1].EntradasAdultoMayor = contadorAdultoM;
                                                    Factura[Factura.Count - 1].EntradasAdulto = contadorAdulto;
                                                    Factura[Factura.Count - 1].subTotal = subTotal;
                                                    if (Factura.Count >= 5)
                                                    {
                                                        Factura[Factura.Count - 1].Total = subTotal - (subTotal * 0.05);
                                                    }
                                                    else
                                                    {
                                                        Factura[Factura.Count - 1].Total = subTotal;
                                                    }
                                                    Console.WriteLine("Presione cualquier tecla para ir a la factura.");
                                                    Console.ReadKey();

                                                    Console.Clear();

                                                    for (int F = 0; F < Factura.Count; F++)
                                                    {
                                                        Console.WriteLine("Pelicula: " + Factura[F].NombrePelicula);
                                                        Console.WriteLine("Hora Funcion: " + Factura[F].HoraFuncion);
                                                        Console.WriteLine("Sala: " + Factura[F].Sala);
                                                        Console.WriteLine("Cantidad entradas niño: " + Factura[F].EntradasNiño);
                                                        Console.WriteLine("Cantidad entradas adulto mayor: " + Factura[F].EntradasAdultoMayor);
                                                        Console.WriteLine("Cantidad entradas adulto: " + Factura[F].EntradasAdulto);
                                                        Console.WriteLine("Cantidad entradas subtotal: " + Factura[F].subTotal);
                                                        if (contadorEntradas >= 5)
                                                        {
                                                            Console.WriteLine("Descuento por comprar mas de 5 entradas: " + (Factura[F].subTotal * 0.05));
                                                        }
                                                        Console.WriteLine("Descuento por comprar mas de 5 entradas: 0");
                                                        Console.WriteLine("Cantidad entradas total: " + Factura[F].Total);
                                                        Console.WriteLine("Hora Compra: " + DateTime.Now.ToString());

                                                    }

                                                    Console.WriteLine();
                                                    Console.WriteLine("Presione cualquier tecla para regresar al menu");
                                                    Console.ReadKey();
                                                    //Menu.
                                                    Console.Clear();
                                                    M_Principal();
                                                }

                                            }
                                            else
                                            {
                                                if (x == 7 && y == 9)
                                                {
                                                    if (Sala[2].peliculasSala[4].TablaVerdad[x, y] == false)
                                                    {
                                                        Console.WriteLine("Entrada invalida o Entrada vendida, intentelo de nuevo");
                                                        Console.ReadKey();
                                                        Compra();
                                                    }
                                                    if (Sala[2].peliculasSala[4].Asientos[x, y] != eleccion)
                                                    {
                                                        Console.WriteLine("Entrada invalida o Entrada vendida, intentelo de nuevo");
                                                        Console.ReadKey();
                                                        Compra();
                                                    }
                                                }

                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("NO HAY ASIENTOS DISPONIBLES");
                                }

                                break;

                            default:
                                Console.WriteLine("Horario no existe, intentelo de nuevo.");
                                Console.ReadKey();
                                Compra();
                                break;
                        }
                        break;

                    case "4":
                        Console.WriteLine("Ingrese la hora de inicio:");
                        switch (Console.ReadLine())
                        {
                            case "1":
                                if (RevisarAsientos(3, 0))
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("Asientos:");
                                    imprimir(Sala[3].peliculasSala[0].Asientos);
                                    string eleccion = Console.ReadLine();
                                    for (int x = 0; x < 8; x++)
                                    {
                                        for (int y = 0; y < 10; y++)
                                        {
                                            if (Sala[3].peliculasSala[0].Asientos[x, y] == eleccion && Sala[3].peliculasSala[0].TablaVerdad[x, y] == true)
                                            {
                                                Sala[3].peliculasSala[0].Asientos[x, y] = "X";
                                                Sala[3].peliculasSala[0].TablaVerdad[x, y] = false;
                                                contadorEntradas++;
                                                Console.WriteLine();
                                                Console.WriteLine("Ingrese el tipo de boleto:");
                                                Console.WriteLine("1 - Niños");
                                                Console.WriteLine("2 - Adulto Mayor");
                                                Console.WriteLine("3 - Adultos");
                                                string descuento = Console.ReadLine();
                                                if (descuento == "1")
                                                {
                                                    Console.WriteLine("Descuento: 10%");
                                                    Sala[3].peliculasSala[0].PrecioConDescuento[x, y] = (Sala[3].peliculasSala[0].PrecioTicket) - ((Sala[3].peliculasSala[0].PrecioTicket) * 0.10);
                                                    subTotal += Sala[3].peliculasSala[0].PrecioConDescuento[x, y];
                                                    contadorNiño++;

                                                }
                                                else if (descuento == "2")
                                                {
                                                    Console.WriteLine("Descuento: 20%");
                                                    Sala[3].peliculasSala[0].PrecioConDescuento[x, y] = (Sala[3].peliculasSala[0].PrecioTicket) - ((Sala[3].peliculasSala[0].PrecioTicket) * 0.20);
                                                    subTotal += Sala[3].peliculasSala[0].PrecioConDescuento[x, y];
                                                    contadorAdultoM++;
                                                }
                                                else if (descuento == "3")
                                                {
                                                    Console.WriteLine("Descuento: 0%");
                                                    Sala[3].peliculasSala[0].PrecioConDescuento[x, y] = (Sala[3].peliculasSala[0].PrecioTicket);
                                                    subTotal += Sala[3].peliculasSala[0].PrecioConDescuento[x, y];
                                                    contadorAdulto++;
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Opcion no valida");
                                                }

                                                //Nueva compra.
                                                Console.WriteLine();
                                                Console.WriteLine("¿Desea comprar más boletos? [Y / N: CualquierTecla]");
                                                string nuevo = Console.ReadLine();
                                                if (nuevo == "Y" || nuevo == "y")
                                                {
                                                    Compra();
                                                }
                                                else
                                                {
                                                    Factura.Add(new ResumenCompra());
                                                    Factura[Factura.Count - 1].NombrePelicula = Sala[3].peliculasSala[0].Nombre;
                                                    Factura[Factura.Count - 1].HoraFuncion = Sala[3].peliculasSala[0].Horario;
                                                    Factura[Factura.Count - 1].Sala = Sala[3].peliculasSala[0].Sala;
                                                    Factura[Factura.Count - 1].EntradasNiño = contadorNiño;
                                                    Factura[Factura.Count - 1].EntradasAdultoMayor = contadorAdultoM;
                                                    Factura[Factura.Count - 1].EntradasAdulto = contadorAdulto;
                                                    Factura[Factura.Count - 1].subTotal = subTotal;
                                                    if (Factura.Count >= 5)
                                                    {
                                                        Factura[Factura.Count - 1].Total = subTotal - (subTotal * 0.05);
                                                    }
                                                    else
                                                    {
                                                        Factura[Factura.Count - 1].Total = subTotal;
                                                    }
                                                    Console.WriteLine("Presione cualquier tecla para ir a la factura.");
                                                    Console.ReadKey();

                                                    Console.Clear();

                                                    for (int F = 0; F < Factura.Count; F++)
                                                    {
                                                        Console.WriteLine("Pelicula: " + Factura[F].NombrePelicula);
                                                        Console.WriteLine("Hora Funcion: " + Factura[F].HoraFuncion);
                                                        Console.WriteLine("Sala: " + Factura[F].Sala);
                                                        Console.WriteLine("Cantidad entradas niño: " + Factura[F].EntradasNiño);
                                                        Console.WriteLine("Cantidad entradas adulto mayor: " + Factura[F].EntradasAdultoMayor);
                                                        Console.WriteLine("Cantidad entradas adulto: " + Factura[F].EntradasAdulto);
                                                        Console.WriteLine("Cantidad entradas subtotal: " + Factura[F].subTotal);
                                                        if (contadorEntradas >= 5)
                                                        {
                                                            Console.WriteLine("Descuento por comprar mas de 5 entradas: " + (Factura[F].subTotal * 0.05));
                                                        }
                                                        Console.WriteLine("Descuento por comprar mas de 5 entradas: 0");
                                                        Console.WriteLine("Cantidad entradas total: " + Factura[F].Total);
                                                        Console.WriteLine("Hora Compra: " + DateTime.Now.ToString());

                                                    }

                                                    Console.WriteLine();
                                                    Console.WriteLine("Presione cualquier tecla para regresar al menu");
                                                    Console.ReadKey();
                                                    //Menu.
                                                    Console.Clear();
                                                    M_Principal();
                                                }

                                            }
                                            else
                                            {
                                                if (x == 7 && y == 9)
                                                {
                                                    if (Sala[3].peliculasSala[0].TablaVerdad[x, y] == false)
                                                    {
                                                        Console.WriteLine("Entrada invalida o Entrada vendida, intentelo de nuevo");
                                                        Console.ReadKey();
                                                        Compra();
                                                    }
                                                    if (Sala[3].peliculasSala[0].Asientos[x, y] != eleccion)
                                                    {
                                                        Console.WriteLine("Entrada invalida o Entrada vendida, intentelo de nuevo");
                                                        Console.ReadKey();
                                                        Compra();
                                                    }
                                                }

                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("NO HAY ASIENTOS DISPONIBLES");
                                }

                                break;

                            case "3":
                                if (RevisarAsientos(3, 1))
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("Asientos:");
                                    imprimir(Sala[3].peliculasSala[1].Asientos);
                                    string eleccion = Console.ReadLine();
                                    for (int x = 0; x < 8; x++)
                                    {
                                        for (int y = 0; y < 10; y++)
                                        {
                                            if (Sala[3].peliculasSala[1].Asientos[x, y] == eleccion && Sala[3].peliculasSala[1].TablaVerdad[x, y] == true)
                                            {
                                                Sala[3].peliculasSala[1].Asientos[x, y] = "X";
                                                Sala[3].peliculasSala[1].TablaVerdad[x, y] = false;
                                                contadorEntradas++;
                                                Console.WriteLine();
                                                Console.WriteLine("Ingrese el tipo de boleto:");
                                                Console.WriteLine("1 - Niños");
                                                Console.WriteLine("2 - Adulto Mayor");
                                                Console.WriteLine("3 - Adultos");
                                                string descuento = Console.ReadLine();
                                                if (descuento == "1")
                                                {
                                                    Console.WriteLine("Descuento: 10%");
                                                    Sala[3].peliculasSala[1].PrecioConDescuento[x, y] = (Sala[3].peliculasSala[1].PrecioTicket) - ((Sala[3].peliculasSala[1].PrecioTicket) * 0.10);
                                                    subTotal += Sala[3].peliculasSala[1].PrecioConDescuento[x, y];
                                                    contadorNiño++;

                                                }
                                                else if (descuento == "2")
                                                {
                                                    Console.WriteLine("Descuento: 20%");
                                                    Sala[3].peliculasSala[1].PrecioConDescuento[x, y] = (Sala[3].peliculasSala[1].PrecioTicket) - ((Sala[3].peliculasSala[1].PrecioTicket) * 0.20);
                                                    subTotal += Sala[3].peliculasSala[1].PrecioConDescuento[x, y];
                                                    contadorAdultoM++;
                                                }
                                                else if (descuento == "3")
                                                {
                                                    Console.WriteLine("Descuento: 0%");
                                                    Sala[3].peliculasSala[1].PrecioConDescuento[x, y] = (Sala[3].peliculasSala[1].PrecioTicket);
                                                    subTotal += Sala[3].peliculasSala[1].PrecioConDescuento[x, y];
                                                    contadorAdulto++;
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Opcion no valida");
                                                }

                                                //Nueva compra.
                                                Console.WriteLine();
                                                Console.WriteLine("¿Desea comprar más boletos? [Y / N: CualquierTecla]");
                                                string nuevo = Console.ReadLine();
                                                if (nuevo == "Y" || nuevo == "y")
                                                {
                                                    Compra();
                                                }
                                                else
                                                {
                                                    Factura.Add(new ResumenCompra());
                                                    Factura[Factura.Count - 1].NombrePelicula = Sala[3].peliculasSala[1].Nombre;
                                                    Factura[Factura.Count - 1].HoraFuncion = Sala[3].peliculasSala[1].Horario;
                                                    Factura[Factura.Count - 1].Sala = Sala[3].peliculasSala[1].Sala;
                                                    Factura[Factura.Count - 1].EntradasNiño = contadorNiño;
                                                    Factura[Factura.Count - 1].EntradasAdultoMayor = contadorAdultoM;
                                                    Factura[Factura.Count - 1].EntradasAdulto = contadorAdulto;
                                                    Factura[Factura.Count - 1].subTotal = subTotal;
                                                    if (Factura.Count >= 5)
                                                    {
                                                        Factura[Factura.Count - 1].Total = subTotal - (subTotal * 0.05);
                                                    }
                                                    else
                                                    {
                                                        Factura[Factura.Count - 1].Total = subTotal;
                                                    }
                                                    Console.WriteLine("Presione cualquier tecla para ir a la factura.");
                                                    Console.ReadKey();

                                                    Console.Clear();

                                                    for (int F = 0; F < Factura.Count; F++)
                                                    {
                                                        Console.WriteLine("Pelicula: " + Factura[F].NombrePelicula);
                                                        Console.WriteLine("Hora Funcion: " + Factura[F].HoraFuncion);
                                                        Console.WriteLine("Sala: " + Factura[F].Sala);
                                                        Console.WriteLine("Cantidad entradas niño: " + Factura[F].EntradasNiño);
                                                        Console.WriteLine("Cantidad entradas adulto mayor: " + Factura[F].EntradasAdultoMayor);
                                                        Console.WriteLine("Cantidad entradas adulto: " + Factura[F].EntradasAdulto);
                                                        Console.WriteLine("Cantidad entradas subtotal: " + Factura[F].subTotal);
                                                        if (contadorEntradas >= 5)
                                                        {
                                                            Console.WriteLine("Descuento por comprar mas de 5 entradas: " + (Factura[F].subTotal * 0.05));
                                                        }
                                                        Console.WriteLine("Descuento por comprar mas de 5 entradas: 0");
                                                        Console.WriteLine("Cantidad entradas total: " + Factura[F].Total);
                                                        Console.WriteLine("Hora Compra: " + DateTime.Now.ToString());

                                                    }

                                                    Console.WriteLine();
                                                    Console.WriteLine("Presione cualquier tecla para regresar al menu");
                                                    Console.ReadKey();
                                                    //Menu.
                                                    Console.Clear();
                                                    M_Principal();
                                                }

                                            }
                                            else
                                            {
                                                if (x == 7 && y == 9)
                                                {
                                                    if (Sala[3].peliculasSala[1].TablaVerdad[x, y] == false)
                                                    {
                                                        Console.WriteLine("Entrada invalida o Entrada vendida, intentelo de nuevo");
                                                        Console.ReadKey();
                                                        Compra();
                                                    }
                                                    if (Sala[3].peliculasSala[1].Asientos[x, y] != eleccion)
                                                    {
                                                        Console.WriteLine("Entrada invalida o Entrada vendida, intentelo de nuevo");
                                                        Console.ReadKey();
                                                        Compra();
                                                    }
                                                }

                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("NO HAY ASIENTOS DISPONIBLES");
                                }

                                break;

                            case "5":
                                if (RevisarAsientos(3, 2))
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("Asientos:");
                                    imprimir(Sala[3].peliculasSala[2].Asientos);
                                    string eleccion = Console.ReadLine();
                                    for (int x = 0; x < 8; x++)
                                    {
                                        for (int y = 0; y < 10; y++)
                                        {
                                            if (Sala[3].peliculasSala[2].Asientos[x, y] == eleccion && Sala[3].peliculasSala[2].TablaVerdad[x, y] == true)
                                            {
                                                Sala[3].peliculasSala[2].Asientos[x, y] = "X";
                                                Sala[3].peliculasSala[2].TablaVerdad[x, y] = false;
                                                contadorEntradas++;
                                                Console.WriteLine();
                                                Console.WriteLine("Ingrese el tipo de boleto:");
                                                Console.WriteLine("1 - Niños");
                                                Console.WriteLine("2 - Adulto Mayor");
                                                Console.WriteLine("3 - Adultos");
                                                string descuento = Console.ReadLine();
                                                if (descuento == "1")
                                                {
                                                    Console.WriteLine("Descuento: 10%");
                                                    Sala[3].peliculasSala[2].PrecioConDescuento[x, y] = (Sala[3].peliculasSala[2].PrecioTicket) - ((Sala[3].peliculasSala[2].PrecioTicket) * 0.10);
                                                    subTotal += Sala[3].peliculasSala[2].PrecioConDescuento[x, y];
                                                    contadorNiño++;

                                                }
                                                else if (descuento == "2")
                                                {
                                                    Console.WriteLine("Descuento: 20%");
                                                    Sala[3].peliculasSala[2].PrecioConDescuento[x, y] = (Sala[3].peliculasSala[2].PrecioTicket) - ((Sala[3].peliculasSala[2].PrecioTicket) * 0.20);
                                                    subTotal += Sala[3].peliculasSala[2].PrecioConDescuento[x, y];
                                                    contadorAdultoM++;
                                                }
                                                else if (descuento == "3")
                                                {
                                                    Console.WriteLine("Descuento: 0%");
                                                    Sala[3].peliculasSala[2].PrecioConDescuento[x, y] = (Sala[3].peliculasSala[2].PrecioTicket);
                                                    subTotal += Sala[3].peliculasSala[2].PrecioConDescuento[x, y];
                                                    contadorAdulto++;
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Opcion no valida");
                                                }

                                                //Nueva compra.
                                                Console.WriteLine();
                                                Console.WriteLine("¿Desea comprar más boletos? [Y / N: CualquierTecla]");
                                                string nuevo = Console.ReadLine();
                                                if (nuevo == "Y" || nuevo == "y")
                                                {
                                                    Compra();
                                                }
                                                else
                                                {
                                                    Factura.Add(new ResumenCompra());
                                                    Factura[Factura.Count - 1].NombrePelicula = Sala[3].peliculasSala[2].Nombre;
                                                    Factura[Factura.Count - 1].HoraFuncion = Sala[3].peliculasSala[2].Horario;
                                                    Factura[Factura.Count - 1].Sala = Sala[3].peliculasSala[2].Sala;
                                                    Factura[Factura.Count - 1].EntradasNiño = contadorNiño;
                                                    Factura[Factura.Count - 1].EntradasAdultoMayor = contadorAdultoM;
                                                    Factura[Factura.Count - 1].EntradasAdulto = contadorAdulto;
                                                    Factura[Factura.Count - 1].subTotal = subTotal;
                                                    if (Factura.Count >= 5)
                                                    {
                                                        Factura[Factura.Count - 1].Total = subTotal - (subTotal * 0.05);
                                                    }
                                                    else
                                                    {
                                                        Factura[Factura.Count - 1].Total = subTotal;
                                                    }
                                                    Console.WriteLine("Presione cualquier tecla para ir a la factura.");
                                                    Console.ReadKey();

                                                    Console.Clear();

                                                    for (int F = 0; F < Factura.Count; F++)
                                                    {
                                                        Console.WriteLine("Pelicula: " + Factura[F].NombrePelicula);
                                                        Console.WriteLine("Hora Funcion: " + Factura[F].HoraFuncion);
                                                        Console.WriteLine("Sala: " + Factura[F].Sala);
                                                        Console.WriteLine("Cantidad entradas niño: " + Factura[F].EntradasNiño);
                                                        Console.WriteLine("Cantidad entradas adulto mayor: " + Factura[F].EntradasAdultoMayor);
                                                        Console.WriteLine("Cantidad entradas adulto: " + Factura[F].EntradasAdulto);
                                                        Console.WriteLine("Cantidad entradas subtotal: " + Factura[F].subTotal);
                                                        if (contadorEntradas >= 5)
                                                        {
                                                            Console.WriteLine("Descuento por comprar mas de 5 entradas: " + (Factura[F].subTotal * 0.05));
                                                        }
                                                        Console.WriteLine("Descuento por comprar mas de 5 entradas: 0");
                                                        Console.WriteLine("Cantidad entradas total: " + Factura[F].Total);
                                                        Console.WriteLine("Hora Compra: " + DateTime.Now.ToString());

                                                    }

                                                    Console.WriteLine();
                                                    Console.WriteLine("Presione cualquier tecla para regresar al menu");
                                                    Console.ReadKey();
                                                    //Menu.
                                                    Console.Clear();
                                                    M_Principal();
                                                }

                                            }
                                            else
                                            {
                                                if (x == 7 && y == 9)
                                                {
                                                    if (Sala[3].peliculasSala[2].TablaVerdad[x, y] == false)
                                                    {
                                                        Console.WriteLine("Entrada invalida o Entrada vendida, intentelo de nuevo");
                                                        Console.ReadKey();
                                                        Compra();
                                                    }
                                                    if (Sala[3].peliculasSala[2].Asientos[x, y] != eleccion)
                                                    {
                                                        Console.WriteLine("Entrada invalida o Entrada vendida, intentelo de nuevo");
                                                        Console.ReadKey();
                                                        Compra();
                                                    }
                                                }

                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("NO HAY ASIENTOS DISPONIBLES");
                                }

                                break;

                            case "7":
                                if (RevisarAsientos(3, 3))
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("Asientos:");
                                    imprimir(Sala[3].peliculasSala[3].Asientos);
                                    string eleccion = Console.ReadLine();
                                    for (int x = 0; x < 8; x++)
                                    {
                                        for (int y = 0; y < 10; y++)
                                        {
                                            if (Sala[3].peliculasSala[3].Asientos[x, y] == eleccion && Sala[3].peliculasSala[3].TablaVerdad[x, y] == true)
                                            {
                                                Sala[3].peliculasSala[3].Asientos[x, y] = "X";
                                                Sala[3].peliculasSala[3].TablaVerdad[x, y] = false;
                                                contadorEntradas++;
                                                Console.WriteLine();
                                                Console.WriteLine("Ingrese el tipo de boleto:");
                                                Console.WriteLine("1 - Niños");
                                                Console.WriteLine("2 - Adulto Mayor");
                                                Console.WriteLine("3 - Adultos");
                                                string descuento = Console.ReadLine();
                                                if (descuento == "1")
                                                {
                                                    Console.WriteLine("Descuento: 10%");
                                                    Sala[3].peliculasSala[3].PrecioConDescuento[x, y] = (Sala[3].peliculasSala[3].PrecioTicket) - ((Sala[3].peliculasSala[3].PrecioTicket) * 0.10);
                                                    subTotal += Sala[3].peliculasSala[3].PrecioConDescuento[x, y];
                                                    contadorNiño++;

                                                }
                                                else if (descuento == "2")
                                                {
                                                    Console.WriteLine("Descuento: 20%");
                                                    Sala[3].peliculasSala[3].PrecioConDescuento[x, y] = (Sala[3].peliculasSala[3].PrecioTicket) - ((Sala[3].peliculasSala[3].PrecioTicket) * 0.20);
                                                    subTotal += Sala[3].peliculasSala[3].PrecioConDescuento[x, y];
                                                    contadorAdultoM++;
                                                }
                                                else if (descuento == "3")
                                                {
                                                    Console.WriteLine("Descuento: 0%");
                                                    Sala[3].peliculasSala[3].PrecioConDescuento[x, y] = (Sala[3].peliculasSala[3].PrecioTicket);
                                                    subTotal += Sala[3].peliculasSala[3].PrecioConDescuento[x, y];
                                                    contadorAdulto++;
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Opcion no valida");
                                                }

                                                //Nueva compra.
                                                Console.WriteLine();
                                                Console.WriteLine("¿Desea comprar más boletos? [Y / N: CualquierTecla]");
                                                string nuevo = Console.ReadLine();
                                                if (nuevo == "Y" || nuevo == "y")
                                                {
                                                    Compra();
                                                }
                                                else
                                                {
                                                    Factura.Add(new ResumenCompra());
                                                    Factura[Factura.Count - 1].NombrePelicula = Sala[3].peliculasSala[3].Nombre;
                                                    Factura[Factura.Count - 1].HoraFuncion = Sala[3].peliculasSala[3].Horario;
                                                    Factura[Factura.Count - 1].Sala = Sala[3].peliculasSala[3].Sala;
                                                    Factura[Factura.Count - 1].EntradasNiño = contadorNiño;
                                                    Factura[Factura.Count - 1].EntradasAdultoMayor = contadorAdultoM;
                                                    Factura[Factura.Count - 1].EntradasAdulto = contadorAdulto;
                                                    Factura[Factura.Count - 1].subTotal = subTotal;
                                                    if (Factura.Count >= 5)
                                                    {
                                                        Factura[Factura.Count - 1].Total = subTotal - (subTotal * 0.05);
                                                    }
                                                    else
                                                    {
                                                        Factura[Factura.Count - 1].Total = subTotal;
                                                    }
                                                    Console.WriteLine("Presione cualquier tecla para ir a la factura.");
                                                    Console.ReadKey();

                                                    Console.Clear();

                                                    for (int F = 0; F < Factura.Count; F++)
                                                    {
                                                        Console.WriteLine("Pelicula: " + Factura[F].NombrePelicula);
                                                        Console.WriteLine("Hora Funcion: " + Factura[F].HoraFuncion);
                                                        Console.WriteLine("Sala: " + Factura[F].Sala);
                                                        Console.WriteLine("Cantidad entradas niño: " + Factura[F].EntradasNiño);
                                                        Console.WriteLine("Cantidad entradas adulto mayor: " + Factura[F].EntradasAdultoMayor);
                                                        Console.WriteLine("Cantidad entradas adulto: " + Factura[F].EntradasAdulto);
                                                        Console.WriteLine("Cantidad entradas subtotal: " + Factura[F].subTotal);
                                                        if (contadorEntradas >= 5)
                                                        {
                                                            Console.WriteLine("Descuento por comprar mas de 5 entradas: " + (Factura[F].subTotal * 0.05));
                                                        }
                                                        Console.WriteLine("Descuento por comprar mas de 5 entradas: 0");
                                                        Console.WriteLine("Cantidad entradas total: " + Factura[F].Total);
                                                        Console.WriteLine("Hora Compra: " + DateTime.Now.ToString());

                                                    }

                                                    Console.WriteLine();
                                                    Console.WriteLine("Presione cualquier tecla para regresar al menu");
                                                    Console.ReadKey();
                                                    //Menu.
                                                    Console.Clear();
                                                    M_Principal();
                                                }

                                            }
                                            else
                                            {
                                                if (x == 7 && y == 9)
                                                {
                                                    if (Sala[3].peliculasSala[3].TablaVerdad[x, y] == false)
                                                    {
                                                        Console.WriteLine("Entrada invalida o Entrada vendida, intentelo de nuevo");
                                                        Console.ReadKey();
                                                        Compra();
                                                    }
                                                    if (Sala[3].peliculasSala[3].Asientos[x, y] != eleccion)
                                                    {
                                                        Console.WriteLine("Entrada invalida o Entrada vendida, intentelo de nuevo");
                                                        Console.ReadKey();
                                                        Compra();
                                                    }
                                                }

                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("NO HAY ASIENTOS DISPONIBLES");
                                }

                                break;

                            case "9":
                                if (RevisarAsientos(3, 4))
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("Asientos:");
                                    imprimir(Sala[3].peliculasSala[4].Asientos);
                                    string eleccion = Console.ReadLine();
                                    for (int x = 0; x < 8; x++)
                                    {
                                        for (int y = 0; y < 10; y++)
                                        {
                                            if (Sala[3].peliculasSala[4].Asientos[x, y] == eleccion && Sala[3].peliculasSala[4].TablaVerdad[x, y] == true)
                                            {
                                                Sala[3].peliculasSala[4].Asientos[x, y] = "X";
                                                Sala[3].peliculasSala[4].TablaVerdad[x, y] = false;
                                                contadorEntradas++;
                                                Console.WriteLine();
                                                Console.WriteLine("Ingrese el tipo de boleto:");
                                                Console.WriteLine("1 - Niños");
                                                Console.WriteLine("2 - Adulto Mayor");
                                                Console.WriteLine("3 - Adultos");
                                                string descuento = Console.ReadLine();
                                                if (descuento == "1")
                                                {
                                                    Console.WriteLine("Descuento: 10%");
                                                    Sala[3].peliculasSala[4].PrecioConDescuento[x, y] = (Sala[3].peliculasSala[4].PrecioTicket) - ((Sala[3].peliculasSala[4].PrecioTicket) * 0.10);
                                                    subTotal += Sala[3].peliculasSala[4].PrecioConDescuento[x, y];
                                                    contadorNiño++;

                                                }
                                                else if (descuento == "2")
                                                {
                                                    Console.WriteLine("Descuento: 20%");
                                                    Sala[3].peliculasSala[4].PrecioConDescuento[x, y] = (Sala[3].peliculasSala[4].PrecioTicket) - ((Sala[3].peliculasSala[4].PrecioTicket) * 0.20);
                                                    subTotal += Sala[3].peliculasSala[4].PrecioConDescuento[x, y];
                                                    contadorAdultoM++;
                                                }
                                                else if (descuento == "3")
                                                {
                                                    Console.WriteLine("Descuento: 0%");
                                                    Sala[3].peliculasSala[4].PrecioConDescuento[x, y] = (Sala[3].peliculasSala[4].PrecioTicket);
                                                    subTotal += Sala[3].peliculasSala[4].PrecioConDescuento[x, y];
                                                    contadorAdulto++;
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Opcion no valida");
                                                }

                                                //Nueva compra.
                                                Console.WriteLine();
                                                Console.WriteLine("¿Desea comprar más boletos? [Y / N: CualquierTecla]");
                                                string nuevo = Console.ReadLine();
                                                if (nuevo == "Y" || nuevo == "y")
                                                {
                                                    Compra();
                                                }
                                                else
                                                {
                                                    Factura.Add(new ResumenCompra());
                                                    Factura[Factura.Count - 1].NombrePelicula = Sala[3].peliculasSala[4].Nombre;
                                                    Factura[Factura.Count - 1].HoraFuncion = Sala[3].peliculasSala[4].Horario;
                                                    Factura[Factura.Count - 1].Sala = Sala[3].peliculasSala[4].Sala;
                                                    Factura[Factura.Count - 1].EntradasNiño = contadorNiño;
                                                    Factura[Factura.Count - 1].EntradasAdultoMayor = contadorAdultoM;
                                                    Factura[Factura.Count - 1].EntradasAdulto = contadorAdulto;
                                                    Factura[Factura.Count - 1].subTotal = subTotal;
                                                    if (Factura.Count >= 5)
                                                    {
                                                        Factura[Factura.Count - 1].Total = subTotal - (subTotal * 0.05);
                                                    }
                                                    else
                                                    {
                                                        Factura[Factura.Count - 1].Total = subTotal;
                                                    }
                                                    Console.WriteLine("Presione cualquier tecla para ir a la factura.");
                                                    Console.ReadKey();

                                                    Console.Clear();

                                                    for (int F = 0; F < Factura.Count; F++)
                                                    {
                                                        Console.WriteLine("Pelicula: " + Factura[F].NombrePelicula);
                                                        Console.WriteLine("Hora Funcion: " + Factura[F].HoraFuncion);
                                                        Console.WriteLine("Sala: " + Factura[F].Sala);
                                                        Console.WriteLine("Cantidad entradas niño: " + Factura[F].EntradasNiño);
                                                        Console.WriteLine("Cantidad entradas adulto mayor: " + Factura[F].EntradasAdultoMayor);
                                                        Console.WriteLine("Cantidad entradas adulto: " + Factura[F].EntradasAdulto);
                                                        Console.WriteLine("Cantidad entradas subtotal: " + Factura[F].subTotal);
                                                        if (contadorEntradas >= 5)
                                                        {
                                                            Console.WriteLine("Descuento por comprar mas de 5 entradas: " + (Factura[F].subTotal * 0.05));
                                                        }
                                                        Console.WriteLine("Descuento por comprar mas de 5 entradas: 0");
                                                        Console.WriteLine("Cantidad entradas total: " + Factura[F].Total);
                                                        Console.WriteLine("Hora Compra: " + DateTime.Now.ToString());

                                                    }

                                                    Console.WriteLine();
                                                    Console.WriteLine("Presione cualquier tecla para regresar al menu");
                                                    Console.ReadKey();
                                                    //Menu.
                                                    Console.Clear();
                                                    M_Principal();
                                                }

                                            }
                                            else
                                            {
                                                if (x == 7 && y == 9)
                                                {
                                                    if (Sala[3].peliculasSala[4].TablaVerdad[x, y] == false)
                                                    {
                                                        Console.WriteLine("Entrada invalida o Entrada vendida, intentelo de nuevo");
                                                        Console.ReadKey();
                                                        Compra();
                                                    }
                                                    if (Sala[3].peliculasSala[4].Asientos[x, y] != eleccion)
                                                    {
                                                        Console.WriteLine("Entrada invalida o Entrada vendida, intentelo de nuevo");
                                                        Console.ReadKey();
                                                        Compra();
                                                    }
                                                }

                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("NO HAY ASIENTOS DISPONIBLES");
                                }

                                break;

                            default:
                                Console.WriteLine("Horario no existe, intentelo de nuevo.");
                                Console.ReadKey();
                                Ingreso();
                                break;
                        }
                        break;

                    default:
                        Console.WriteLine("Sala no existe, intente de nuevo");
                        Console.ReadKey();
                        Compra();
                        break;
                }
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("No puede comprar más de 10 entradas");
            }
        }

        static int contadorNiño = 0;
        static int contadorAdulto = 0;
        static int contadorAdultoM = 0;

        static double subTotal = 0;


        //Programa.
        static void Main(string[] args)
        {
            Sala.Add(new SalaCine());
            Sala.Add(new SalaCine());
            Sala.Add(new SalaCine());
            Sala.Add(new SalaCine());
            
            //Instancias de peliculas. (5 por sala)
            Sala[0].peliculasSala.Add(new Pelicula());
            Sala[0].peliculasSala.Add(new Pelicula());
            Sala[0].peliculasSala.Add(new Pelicula());
            Sala[0].peliculasSala.Add(new Pelicula());
            Sala[0].peliculasSala.Add(new Pelicula());

            Sala[1].peliculasSala.Add(new Pelicula());
            Sala[1].peliculasSala.Add(new Pelicula());
            Sala[1].peliculasSala.Add(new Pelicula());
            Sala[1].peliculasSala.Add(new Pelicula());
            Sala[1].peliculasSala.Add(new Pelicula());

            Sala[2].peliculasSala.Add(new Pelicula());
            Sala[2].peliculasSala.Add(new Pelicula());
            Sala[2].peliculasSala.Add(new Pelicula());
            Sala[2].peliculasSala.Add(new Pelicula());
            Sala[2].peliculasSala.Add(new Pelicula());

            Sala[3].peliculasSala.Add(new Pelicula());
            Sala[3].peliculasSala.Add(new Pelicula());
            Sala[3].peliculasSala.Add(new Pelicula());
            Sala[3].peliculasSala.Add(new Pelicula());
            Sala[3].peliculasSala.Add(new Pelicula());

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    for (int x = 0; x < 8; x++)
                    {
                        for (int y = 0; y < 10; y++)
                        {
                            Sala[i].peliculasSala[j].TablaVerdad[x, y] = true;
                            if (x==0)
                            {
                                Sala[i].peliculasSala[j].Asientos[x, y] = "A"+ (y+1);
                            }
                            else if (x == 1)
                            {
                                Sala[i].peliculasSala[j].Asientos[x, y] = "B" + (y + 1);
                            }
                            else if(x == 2)
                            {
                                Sala[i].peliculasSala[j].Asientos[x, y] = "C" + (y + 1);
                            }
                            else if (x == 3)
                            {
                                Sala[i].peliculasSala[j].Asientos[x, y] = "D" + (y + 1);
                            }
                            else if (x == 4)
                            {
                                Sala[i].peliculasSala[j].Asientos[x, y] = "E" + (y + 1);
                            }
                            else if (x == 5)
                            {
                                Sala[i].peliculasSala[j].Asientos[x, y] = "F" + (y + 1);
                            }
                            else if (x == 6)
                            {
                                Sala[i].peliculasSala[j].Asientos[x, y] = "G" + (y + 1);
                            }
                            else if (x == 7)
                            {
                                Sala[i].peliculasSala[j].Asientos[x, y] = "H" + (y + 1);
                            }
                        }
                    }
                }
            }

            M_Principal();
            Console.ReadKey(); //No deja que se cierre la consola.
        }
    }
}
