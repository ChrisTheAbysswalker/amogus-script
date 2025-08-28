using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Compilador
{
    internal class Sintactico : clsMatrices
    {
        List<string> lstTokensLex = new List<string>();
        List<string> lstErrores = new List<string>();
        List<string> lstLineas = new List<string>();
        List<string> lstPalabras = new List<string>();
        
        public void GetTokens(ref DataTable tabla)
        {
            foreach (DataRow row in tabla.Rows)
            {
                lstTokensLex.Add(row[0].ToString());
                lstPalabras.Add(row[1].ToString());
                lstLineas.Add(row[2].ToString());
            };
        }

        public void AnalisisSintactico()
        {
            lstErrores.Clear();
            int[,] matriz = MatrizSintaxis();
            ClsPila pila = new ClsPila();
            int cont = 0, col = 0, token = 0, estado = 0;
            string[] tokens = new string[lstTokensLex.Count];
            bool hayIf = false, cerroIf = false;
            string tokenEndIf = "";
            int contador = 0;
            for (int i = 0; i < lstTokensLex.Count; i++)
            {
                tokens[i] = lstTokensLex[i].ToString();
            }
            try {
                if (tokens[0] != "224")
                    lstErrores.Add("ERROR 430: Se debe de empezar el programa con amogus seguido del nombre");
            } catch (Exception) { }
            for (int i = 0; i < lstTokensLex.Count; i++)
            {
                tokenEndIf = lstTokensLex[i].ToString().Trim();
                if (tokenEndIf == "221") contador++;
            }
            while (cont <= lstTokensLex.Count)
            {
                token = cont < lstTokensLex.Count ? Convert.ToInt32(tokens[cont].Trim()) : 0;
                if (token == 221)
                {
                    if (hayIf) cerroIf = true;
                    if (!pila.estavacia())
                    {
                        if (pila.Peek() == "504")
                        {
                            if (cerroIf)
                            {
                                hayIf = false;
                                cerroIf = false;
                                pila.Pop();
                                if (pila.Peek() == "500") pila.Pop();
                            }
                            else
                            {
                                pila.Pop();
                                lstErrores.Add("ERROR 429: esta usando un choice sin antes declarar un condit");
                            }
                        }
                        else
                        {
                            if (pila.Peek() == "500")
                            {
                                pila.Pop();
                                cerroIf = true;
                                hayIf = false;
                                cont++;
                                continue;
                            }
                            pila.Pop();
                            cerroIf = false;
                            hayIf = false;
                        }
                    }
                    else
                    {
                        if (pila.Size() == 0) lstErrores.Add("ERROR 428: Hay endit de mas");
                    }
                    cont++;
                    continue;
                }

                if (token >= 400)
                {
                    Func<int, string> obtenerErr = new Func<int, string>((tkn) =>
                    {
                        Dictionary<int, string> dicErrs = new Dictionary<int, string>() {
                        { 401, "ERROR 401: Caracter NO Reconocido" },
                        { 402, "ERROR 402: Se Espera un '" },
                        { 403, "ERROR 403: Error en Numero" },
                        { 404, "ERROR 404: Se Espera un   +   o un  - " },
                        { 405, "ERROR 405: Identificador Demaciado Largo" } };
                        return dicErrs.TryGetValue(token, out var mensaje) ? mensaje : "No se encontró ningún error";
                    });
                    lstErrores.Add(obtenerErr(token));
                    cont++;
                    continue;
                }
                col = RecorrerColumna(token);
                estado = matriz[estado, col];
                if (estado >= 400)
                {
                    if (estado >= 500)
                    {
                        if (estado == 500 || estado == 504 || estado == 503 || estado == 509 || estado == 505)
                        {
                            if (hayIf == true) hayIf = false;
                            pila.Push(estado.ToString());
                        }
                        estado = 0;
                        if (pila.Peek() == "500") hayIf = true;
                    }
                    if (estado >= 400 && estado <= 430)
                    {
                        Errores(estado, lstLineas[cont-1].ToString());
                        estado = 0;
                    }
                    cont++;
                    continue;
                }
                cont++;
            }
            if (!pila.estavacia()) lstErrores.Add("ERROR 427: Hace falta algun endit");
        }

        private int RecorrerColumna(int token)
        {
            int[] noToken = { 100, 101, 102, 103, 104, 105, 106, 107, 108, 109, 110, 111, 112, 113, 231, 124, 116, 117, 118, 119, 120, 121, 122, 123, 126, 200, 201, 202, 203, 204, 205, 207, 209, 210, 220, 221, 222, 223, 214, 215, 224, 226, 225, 227, 232, 216 };
            int[] estado = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42 };
            int indice = Array.IndexOf(noToken, token);
            return indice > -1 ? estado[indice] : 0;
        }

        private void Errores(int token, string ln)
        {
            Dictionary<int, string> errores = new Dictionary<int, string>()
            {   { 410, "ERROR 410: Error de sintaxis, se esperaba una variable o palabra reservada" },
                { 411, "ERROR 411: Se espera un '('"},
                { 412, "ERROR 412: Se espera var, cad, num"},
                { 413, "ERROR 413: Se espera Op. Relacional"},
                { 414, "ERROR 414: Se espera un ')' seguido de la reservada through"},
                { 415, "ERROR 415: Se espera through"},
                { 416, "ERROR 416: Se espera '=', Tambien podria ser un incremento o decremento"},
                { 417, "ERROR 417: Se espera ';'"},
                { 418, "ERROR 418: Se espera un tipo de variable"},
                { 419, "ERROR 419: Se espera una variable"},
                { 420, "ERROR 420: Se espera ';'"},
                { 421, "ERROR 421: Se espera starit"},
                { 422, "ERROR 422: Se espera ')'"},
                { 423, "ERROR 423: Se espera ';'"},
                { 424, "ERROR 424: Se espera una variable o cadena"},
                { 425, "ERROR 425: Se espera un nombre para el programa"},
                { 426, "ERROR 426: Se espera '++' o '--'"} };
            string mensajeError = errores.TryGetValue(token, out var mensaje) ? mensaje : "No se encontró ningún error";
            lstErrores.Add($"Ln:{ln}, "+mensajeError);
        }

        public List<string> GetErrores() => lstErrores;
        public List<string> GetTokens() => lstTokensLex;
        public List<string> GetPalabras() => lstPalabras;
    }
}