﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace Compilador
{
    internal class Asm
    {

        List<string> token_variables = new List<string>();
        List<string> variables = new List<string>();
        List<string> contenido_vars = new List<string>();
        List<string> tokens = new List<string>();
        List<string> lineas = new List<string>();
        List<string> contenido = new List<string>();


        List<string> tkn_ifelse = new List<string>();
        List<string> lista_ifelse = new List<string>();
        List<string> lista_lineas = new List<string>();
        public Asm(List<string> variables, List<string> tokens_code, List<string> contenido_code, List<string> lineas_code, List<string> tokens_variables, List<string> contenido_variables)
        {
            this.variables = variables;
            this.tokens = tokens_code;
            this.contenido = contenido_code;
            this.lineas = lineas_code;
            this.token_variables = tokens_variables;
            this.contenido_vars = contenido_variables;


            for (int i = 0; i < tokens.Count; i++)
            {
                if (Convert.ToInt32(tokens[i]) == 205 || Convert.ToInt32(tokens[i]) == 209 || Convert.ToInt32(tokens[i]) == 207 || Convert.ToInt32(tokens[i]) == 221 || Convert.ToInt32(tokens[i]) == 224)
                {
                    tkn_ifelse.Add(tokens_code[i]);
                    lista_ifelse.Add(contenido_code[i]);
                    lista_lineas.Add(lineas_code[i]);
                }
            }
            int num = BscarFin_IF(ref linea_finElse);
            if (num > 0)
            {
                linea_finIf = num;
            }
        }
        int linea_finIf;
        int linea_finElse;
        private int BscarFin_IF(ref int linea_else)
        {
            int ln = 0;
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < tkn_ifelse.Count; i++)
            {
                if (Convert.ToInt32(tkn_ifelse[i]) == clsTokens.Choice)
                {
                    ln = Convert.ToInt32(lista_lineas[i - 1]);
                    linea_finElse = Convert.ToInt32(lista_lineas[i + 1]);
                }
            }
            return ln;
        }

        public string Codigo_ASM()
        {
            string codigo = "";
            codigo += ConvertirVariables(token_variables, variables, contenido_vars);
            codigo += BeginCode();
            codigo += LeerCodigo();
            codigo += EndCode();
            return codigo;
        }

        private string ConvertirVariables(List<string> tkn, List<string> vars, List<string> contenido)
        {
            string code = ".Model Small\n.Stack 100h\n.Data\n";
            string ln, val;
            code += "buffer db 12 dup('$')\n";
            for (int i = 0; i < vars.Count; i++)
            {
                ln = vars[i];
                val = contenido[i];
                code += Convert.ToInt32(tkn[i]) == clsTokens.Cadena ? $"{ln} dw {val}\n" : $"{ln} dw ?\n";
            }
            return code;
        }

        private string BeginCode() => $"\n.Code \nMain Proc \nmov ax, @Data \nmov ds, ax \n";
        private string EndCode() => "mov ah, 4ch \nint 21h \nmain endp \nend main";
        int ubicacion_else;
        public string LeerCodigo()
        {
            var tupla = CodigoLineas(contenido, lineas);
            string[] tokens = tupla.Item1.Split('\n');
            string[] codigo = tupla.Item2.Split('\n');
            string[] ln;
            string[] tk;
            int[] tkInt;
            char[] separadores = { ' ' };
            string lineaCodigo = "";
            string code = "";
            bool hay_If = false;
            for (int i = 0; i < codigo.Length; i++)
            {
                ln = codigo[i].Split(separadores, StringSplitOptions.RemoveEmptyEntries);
                tk = tokens[i].Split(separadores, StringSplitOptions.RemoveEmptyEntries);
                tkInt = tk.Select(x => Convert.ToInt32(x)).ToArray();
                for (int j = 0; j < tk.Length; j++)
                {
                    if (Convert.ToInt32(tk[j]) == clsTokens.Amogus || Convert.ToInt32(tk[j]) == clsTokens.Decl)
                    {
                        break;
                    }
                    if (Convert.ToInt32(tk[j]) == clsTokens.Write && Convert.ToInt32(tk[j + 2]) == clsTokens.Cadena)
                    {
                        lineaCodigo = ImprimirMsg();
                        code += lineaCodigo;
                        break;
                    }
                    if (Convert.ToInt32(tk[j]) == clsTokens.Writeln && Convert.ToInt32(tk[j + 2]) == clsTokens.Cadena)
                    {
                        code += "mov ah, 02h\nmov dl, 0dh\nint 21h\nmov dl, 0ah\nint 21h\n";
                        lineaCodigo = ImprimirMsg();
                        code += lineaCodigo;
                        break;
                    }
                    if (Convert.ToInt32(tk[j]) == clsTokens.Write)
                    {
                        lineaCodigo = AsignarValoresVars(tkInt, ln.ToArray());
                        code += lineaCodigo + "\n";
                        break;
                    }
                    if (Convert.ToInt32(tk[j]) == clsTokens.Writeln)
                    {
                        lineaCodigo = AsignarValoresVars(tkInt, ln.ToArray());
                        code += lineaCodigo + "\n";
                        break;
                    }
                    if (Convert.ToInt32(tk[j]) == clsTokens.Variable)
                    {
                        string str = "";
                        for (int k = 2; k < ln.Length - 1; k++)
                        {
                            str += ln[k] + " ";
                        }
                        Dictionary<string, int> dicionarioTokens = CrearDiccionarioTokens(ln, tkInt);
                        List<string> arrPostfix = Postfijo.ConvertirExpresion(str).Split(separadores, StringSplitOptions.RemoveEmptyEntries).ToList();
                        arrPostfix.Add(ln[1]);
                        arrPostfix.Add(ln[0]);
                        arrPostfix.Add(ln[ln.Length - 1]);
                        int[] arrTkn = RecuperarTokens(arrPostfix.ToArray(), dicionarioTokens);
                        lineaCodigo = AsignarValoresVars(arrTkn, arrPostfix.ToArray());
                        code += lineaCodigo + "\n";
                        break;
                    }
                    if (Convert.ToInt32(tk[j]) == clsTokens.Condit) 
                    {
                        code += EvaluarOperador(tk, ln, $"entra_if{contador_if}");
                        PilaControl($"empieza_else{contador_else}:\n", clsTokens.Condit);
                        code += $"\nentra_if{contador_if}:\n";
                        contador_if++;
                        contador_else++;
                        break;
                    }
                    if (Convert.ToInt32(tk[j]) == clsTokens.Choice) 
                    {
                        hay_If = true;
                        //contador_else--;
                        //code += $"jmp fin_if\n";
                        code += $"empieza_else{contador_else}:\n";
                        //PilaControl($"sale_if{contador_if}", Convert.ToInt32(tk[j]));
                        break;
                    }
                    if (Convert.ToInt32(tk[j]) == clsTokens.Ongoing) 
                    {
                        code += $"while{contador_while}:\n";
                        code += EvaluarOperador(tk, ln);
                        PilaControl($"jmp while{contador_while}\nfin_while{contador_while}:", clsTokens.Ongoing);
                        contador_while++;
                        break;
                    }
                    if (i == linea_finIf-1)
                    {
                        code += $"jmp fin_if\n";
                    }
                    if (i == linea_finElse-1)
                    {
                        code += $"fin_if:\n";
                    }
                    if (Convert.ToInt32(tk[j]) == clsTokens.Endit)
                    {
                        string str = PilaControl("", clsTokens.Endit);
                        code += str + "\n";
                    }
                }
            }
            return code;
        }

        private Dictionary<string, int> CrearDiccionarioTokens(string[] lexema, int[] tkn_var)
        {
            Dictionary<string, int> diccionario = new Dictionary<string, int>();
            for (int i = 0; i < lexema.Length; i++)
            {
                string tkn = lexema[i];
                int valor = tkn_var[i];
                diccionario[tkn] = valor;
            }
            return diccionario;
        }
        private int[] RecuperarTokens(string[] lista1, Dictionary<string, int> diccionario)
        {
            List<int> lista2 = new List<int>();
            int[] arr;
            foreach (string token in lista1)
            {
                if (diccionario.TryGetValue(token, out int valor))
                {
                    lista2.Add(valor);
                }
                else
                {
                    continue;
                }
            }
            arr = lista2.ToArray();
            return arr;
        }

        private string AsignarValoresVars(int[] tokens, string[] exp)
        {
            string ax = "", bx = "", cx = "", dx = "";
            string code = "";
            string var = exp[exp.Length - 2];
            List<string> expre = new List<string>();
            List<int> tkn = new List<int>();
            for (int i = 0; i < tokens.Length; i++)
            {
                /* Suma 104   Resta 105   Multi 106   Div 107 */
                /* cadena  126  Num 101    dec 102  */
                if (tokens[i] == clsTokens.NoEntero || tokens[i] == clsTokens.Variable)
                {
                    if (string.IsNullOrEmpty(ax))
                    {
                        ax = exp[i];
                        code += $"\nmov ax, {ax}";
                    }
                    else
                    {
                        bx = exp[i];
                        code += $"\nmov bx, {bx}";
                    }
                }
                if (tokens[i] == clsTokens.Suma)// suma
                {
                    code += $"\nadd ax, bx";
                    //code += $"\nmov {var}, ax";
                }
                if (tokens[i] == clsTokens.Resta) //resta
                {
                    code += $"\nsub ax, bx";
                    //code += $"\nmov {var}, ax";
                }
                if (tokens[i] == clsTokens.Multiplicacion) //multiplicacion
                {
                    if (!string.IsNullOrEmpty(bx))
                    {
                        code += $"\nmul bx";
                        //code += $"\nmov {var}, ax";
                    }
                }
                if (tokens[i] == clsTokens.Division) //division
                {
                    if (!string.IsNullOrEmpty(bx))
                    {
                        code += $"\ndiv bx";
                        //code += $"\nmov {var}, ax";
                    }
                }
                if (tokens[i] == clsTokens.Igual)
                {
                    code += $"\nmov {var}, ax";
                    break;
                }
                if (tokens[i] == clsTokens.Write || tokens[i] == clsTokens.Writeln) 
                {
                    while (tokens[i] != clsTokens.PuntoyComa)
                    {
                        i++;
                        expre.Add(exp[i]);
                        tkn.Add(tokens[i]);
                    }
                    code += Imprimir(tkn, expre);
                }
            }
            return code;
        }
        int cont = 0;
        private string ImpVariosNums(string var) =>  $"\nmov {var}, ax\r\nmov bx, 10 \r\nmov si, offset buffer +11\r\nmov ax,{var}\r\nmov cl, 0 \r\nconvertir{cont}: \r\nxor dx, dx; \r\ndiv bx\r\nadd dl, '0' \r\ndec si\r\n mov [si],dl \r\ntest ax, ax\r\njnz convertir{cont} \r\nmov dx, si \r\nmov ah, 9 \r\nint 21h ";

        private string Imprimir(List<int> tokens, List<string> exp)
        {
            string imp = "";
            string code = ""; ;
            for (int i = 0; i < tokens.Count; i++)
            {
                if (tokens[i] == clsTokens.Variable)
                {
                    imp = exp[i];
                    break;
                }
                else
                    continue;
            }
            //code += ImpVariosNums(imp);
            cont++;
            code = $"\nmov dx, {imp}\nadd dx, 30h\nmov ah, 02h\nint 21h\n";
            return code;
        }

        int messg = 0;
        private string ImprimirMsg()
        {
            string msg = $"msg{messg}";
            string code = $"\nmov ah, 09h\nlea dx, {msg}\nint 21h\n";
            messg++;
            return code;
        }

        public Tuple<string, string> CodigoLineas(List<string> contenido, List<string> linea)
        {
            int ln = 1;
            string lineas = "";
            string tknsLn = "";
            for (int i = 0; i < linea.Count; i++)
            {
                if (ln == Convert.ToInt32(linea[i]))
                {
                    lineas += contenido[i] + " ";
                    tknsLn += tokens[i] + " ";
                }
                if (i != linea.Count - 1)
                {
                    if (ln != Convert.ToInt32(linea[i + 1]))
                    {
                        lineas += "\n";
                        tknsLn += "\n";
                        ln++;
                    }
                }
            }
            return Tuple.Create(tknsLn, lineas);
        }
        
        
        int contador_while = 1;
        int contador_if = 1;
        int contador_else = 1;
        private string EvaluarIf(string[] arr_tokens, string[] arr_lexema, bool hay_else)
        {
            string code = EvaluarOperador(arr_tokens, arr_lexema, $"entra_if{ContarIfs(contador_if)}");
            return code;
        }
        private string EvaluarOperador(string[] arrTokens, string[] arrLexema, string entra_if)
        {
            string code = "", op1 = "", op2 = "";
            for (int i = 0; i < arrTokens.Length; i++)
            {
                if (Convert.ToInt32(arrTokens[i]) == clsTokens.Is)//==
                {
                    op1 = arrLexema[i - 1];
                    op2 = arrLexema[i + 1];
                    code += $"\nmov ax, {op2}\ncmp {op1}, ax\nje {entra_if}\n";
                }
                if (Convert.ToInt32(arrTokens[i]) == clsTokens.Nop)//!=
                {
                    op1 = arrLexema[i - 1];
                    op2 = arrLexema[i + 1];
                    code += $"\nmov ax, {op2}\ncmp {op1}, ax\njne {entra_if}\n";
                }
                if (Convert.ToInt32(arrTokens[i]) == clsTokens.Mayor)//>
                {
                    op1 = arrLexema[i - 1];
                    op2 = arrLexema[i + 1];
                    code += $"\nmov ax, {op2}\ncmp {op1}, ax\njg {entra_if}\n";
                }
                if (Convert.ToInt32(arrTokens[i]) == clsTokens.MayorIgual)//>=
                {
                    op1 = arrLexema[i - 1];
                    op2 = arrLexema[i + 1];
                    code += $"\nmov ax, {op2}\ncmp {op1}, ax\njge {entra_if}\n";
                }
                if (Convert.ToInt32(arrTokens[i]) == clsTokens.Menor)//<
                {
                    op1 = arrLexema[i - 1];
                    op2 = arrLexema[i + 1];
                    code += $"\nmov ax, {op2}\ncmp {op1}, ax\njl {entra_if}\n";
                }
                if (Convert.ToInt32(arrTokens[i]) == clsTokens.MenorIgual)//<=
                {
                    op1 = arrLexema[i - 1];
                    op2 = arrLexema[i + 1];
                    code += $"\nmov ax, {op2}\ncmp {op1}, ax\njle {entra_if}\n";
                }
            }
            code += $"jmp empieza_else{contador_else}\n";
            return code;
        }

        int cantidad_while = 1;

        private string EvaluarOperador(string[] arrTokens, string[] arrLexema)
        {
            string code = "", op1 = "", op2 = "";
            string ongoing = $"fin_while{contador_while}";
            for (int i = 0; i < arrTokens.Length; i++)
            {
                switch (Convert.ToInt32(arrTokens[i]))
                {
                    case 231: // == is
                        op1 = arrLexema[i - 1];
                        op2 = arrLexema[i + 1];
                        code += $"\nmov ax, {op2}\ncmp {op1},ax\njne {ongoing}\n";
                        break;

                    case 216: // != nop
                        op1 = arrLexema[i - 1];
                        op2 = arrLexema[i + 1];
                        code += $"\nmov ax, {op2}\ncmp {op1},ax\nje {ongoing}\n";
                        break;

                    case 110: // >
                        op1 = arrLexema[i - 1];
                        op2 = arrLexema[i + 1];
                        code += $"\nmov ax, {op2}\ncmp {op1},ax\njle {ongoing}\n";
                        break;

                    case 111: // >=
                        op1 = arrLexema[i - 1];
                        op2 = arrLexema[i + 1];
                        code += $"\nmov ax, {op2}\ncmp {op1},ax\njl {ongoing}\n";
                        break;

                    case 112: // <
                        op1 = arrLexema[i - 1];
                        op2 = arrLexema[i + 1];
                        code += $"\nmov ax, {op2}\ncmp {op1},ax\njge {ongoing}\n";
                        break;

                    case 113: // <=
                        op1 = arrLexema[i - 1];
                        op2 = arrLexema[i + 1];
                        code += $"\nmov ax, {op2}\ncmp {op1},ax\njg {ongoing}\n";
                        break;
                }
            }
            return code;
        }

        private int ContarIfs(int cant)
        {
            Stack<int> cantidadIfs = new Stack<int>();
            cantidadIfs.Push(cant);
            return cantidadIfs.Pop();
        }

        Stack<string> pila_control = new Stack<string>();
        private string PilaControl(string str, int tkn)
        {
            string res = "";
            if (tkn == clsTokens.Condit || tkn == clsTokens.Choice || tkn == clsTokens.Ongoing)
            {
                pila_control.Push(str);
            }
            if (pila_control.Any())
            {
                if (tkn == clsTokens.Endit)
                {
                    res = pila_control.Pop();
                }
            }
            return res;
        }
    }
}
