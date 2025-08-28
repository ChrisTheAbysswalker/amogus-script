using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Compilador
{
    internal class Lexico : clsMatrices
    {
        DataTable tabla = new DataTable();
        DataTable tablaErrores = new DataTable();
        List<string> listaErr = new List<string>();

        string[] reservadas = { "number", "decimal", "text", "assert", "glyph", "condit", "alter", "choice", "halt", "ongoing", "function",
                                    "giback", "main", "catchit", "also", "alter", "nop", "real", "unreal", "exclude", "starit", "endit", "write", 
                                       "readln","amogus","through","decl","def", "gg","plus","minus", "is", "writeln", "menoriwal" ,"mayoriwal"};

        char[] arrayCaracteres = { 'ñ', 'ñ', '_', '.', 'e', '+', '-', '*', '/', '<', '>', '=', '#', '(', ')', '[', ']', ',', ';', ':', '\'', 'ñ', ' ', 'ñ' };

        public Lexico()
        {
            tabla.Columns.Add("Lexema");
            tabla.Columns.Add("Token");
            tabla.Columns.Add("Linea");
            tablaErrores.Columns.Add("Lexema");
            tablaErrores.Columns.Add("Token");
            tablaErrores.Columns.Add("Linea");
        }

        public List<string> GetErrLex() => listaErr;

        private string Errores(int noError)
        {
            Dictionary<int, string> errores = new Dictionary<int, string>()
            {   { 401, "ERROR 401: Caracter NO Reconocido" },
                { 402, "ERROR 402: Se Espera un  ' " },
                { 403, "ERROR 403: Error en Numero" },
                { 404, "ERROR 404: Se Espera un '+' o un '-'" },
                { 405, "ERROR 405: Identificador Demasiado Largo" } };
            string err = errores.TryGetValue(noError, out var mensaje) ? mensaje : "";
            listaErr.Add(err);
            return err;
        }

        private void agregarError(int estado, int linea) => tablaErrores.Rows.Add(estado, Errores(estado), linea);

        private int Palabras(string palabra)
        {
            for (int i = 0; i < reservadas.Length; i++)
            {
                if (palabra.ToLower() == reservadas[i].ToString())
                    return 200 + i;
            }
            return 100;
        }

        private int BuscarColumna(char caracter)
        {
            if (char.IsLetter(caracter) && caracter != 'e') return 0;
            else if (char.IsNumber(caracter)) return 1;
            else if (Array.IndexOf(arrayCaracteres, caracter) != -1) return Array.IndexOf(arrayCaracteres, caracter);
            return 21;
        }

        public void AnalisisLex(string textoCompi)
        {
            int[,] matriz = MatrizLexico();
            int ren = 1;
            int col = 0;
            string lexema = "";
            int estado = 0;
            tabla.Clear();
            tablaErrores.Clear();
            for (int i = 0; i < textoCompi.Length; i++)
            {
                col = BuscarColumna(textoCompi[i]);
                estado = matriz[estado, col];
                if (estado <= 16 && estado != 0)
                {
                    lexema += textoCompi[i];
                    if (lexema.Length > 255) estado = 405;
                    if (estado > 400)
                    {
                        agregarError(estado, ren);
                        estado = 0;
                        lexema = "";
                    }
                }
                else if (estado != 0)
                {
                    if (estado == 100 || estado == 101 || estado == 102 || estado == 103 || estado == 104 || estado == 105 || estado == 106 || estado == 107 || estado == 110 || estado == 112 || estado == 124)
                        i--;
                    else
                        if (textoCompi[i] != ' ')
                        lexema += textoCompi[i];
                    if (lexema.Length > 255)
                        estado = 405;
                    if (estado == 100)
                        estado = Palabras(lexema);
                    if (estado > 400)
                        agregarError(estado, ren);
                    else if (estado != 125)
                        tabla.Rows.Add(estado, lexema, ren);
                    lexema = "";
                    estado = 0;
                }
                if (textoCompi[i] == '\n')
                    ren++;
                if (textoCompi.Length - 1 == i && estado != 0)
                {
                    if (lexema.Length > 255)
                        estado = 405;
                    estado = matriz[estado, 21];
                    if (estado == 100)
                        estado = Palabras(lexema);
                    if (estado > 400)
                        agregarError(estado, ren);
                    else if (estado != 125)
                        tabla.Rows.Add(estado, lexema, ren);
                }
            }
        }

        public DataTable TablaTokens() => tabla;

        public DataTable TablaErrores() => tablaErrores;
    }
}