using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compilador
{
	internal class clsLexico
	{
		bool cadena = false;
		int linea = 1;
		int tam = 0;
		int estado = 0;
		int i = 0, col = 0;
		string lexema = "";
		char carac = ' ';
		bool error = false;    //int,        double,   var,     string,    If   then       end      begin    while        or        and     procedure program  else  readln writeln   ++     --   function   
		string[] reservadas = { "number", "decimal", "text", "assert", "glyph", "condit", "alter", "choice", "halt", "ongoing", "function",
				"giback", "main", "catchit", "also", "alter", "nop", "real", "unreal", "exclude", "starit", "endit", "writeln", "readln","amogus","through","decl","def", "gg","plus","minus" };

		List<string> lexemalist = new List<string>();
		List<string> tokenlist = new List<string>();
		List<string> linealist = new List<string>();

		public List<string> GetTokenList() => tokenlist;
		public void AnalisisLexico(string texto)
		{
			//al inciar el metodo se manipulan/limpian variables y ciertos elementos
			//para el correcto funcionamiento del programa.
			error = false;
			lexemalist.Clear();
			tokenlist.Clear();
			linealist.Clear();
			//matriz de excel pasada a c#
			int[,] matriz = {
			{1, 2, 401, 117, 1, 8, 9, 10, 11, 12, 13, 14, 15, 120, 121, 122, 123, 116, 119, 118, 16, 0, 0, 401},
			{1, 1, 100, 100, 1, 100, 1, 100, 100, 100, 100,  100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100},
			{101, 2, 101, 3, 5, 101, 101, 101, 101, 101, 101,  101, 101, 101, 101, 101, 101, 101, 101, 101, 101, 101, 101, 101},
			{403, 4, 403, 403, 403, 403, 403, 403, 403, 403, 403,  403, 403,403, 403, 403, 403, 403, 403, 403, 403, 403, 403, 403},
			{102, 4, 102, 102, 5, 102, 102, 102, 102, 102, 102,  102, 102,102, 102, 102, 102, 102, 102, 102, 102, 102, 102, 102},
			{404, 7, 404, 404, 404, 6, 6, 404, 404, 404, 404, 404,404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404},
			{404, 7, 404, 404, 404, 404, 404, 404, 404, 404, 404,404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404 },
			{103, 7, 103, 103, 103, 103, 103, 103, 103, 103, 103,  103, 103,103, 103, 103, 103, 103, 103, 103, 103, 103, 103, 103 },
			{104, 104, 104, 104, 104, 108, 104, 104, 104, 104, 104, 104, 104, 104, 104, 104, 104, 104, 104, 104, 104, 104, 104, 104 },
			{105, 105, 105, 105, 105, 105, 109, 105, 105, 105,  105,105,  105, 105, 105, 105, 105, 105, 105, 105, 105, 105, 105, 105 },
			{106, 106, 106, 106, 106, 106, 106, 106, 106, 106, 106, 106,106, 106, 106, 106, 106, 106, 106, 106, 106, 106, 106, 106 },
			{107, 107, 107, 107, 107, 107, 107, 107, 107, 107,  107, 107,107, 107, 107, 107, 107, 107, 107, 107, 107, 107, 107, 107 },
			{112, 112, 112, 112, 112, 112, 112, 112, 112, 112, 115, 113, 112,  112, 112,112, 112, 112, 112, 112, 112, 112, 112, 112},
			{110, 110, 110, 110, 110, 110, 110, 110, 110, 110, 110, 111, 110, 110,110, 110, 110, 110, 110, 110, 110, 110, 110, 110},
			{124, 124, 124, 124, 124, 124, 124, 124, 124, 124, 124, 125, 124, 124,124, 124, 124, 124, 124, 124, 124, 124, 124, 124},
			{15, 15, 15, 15, 15, 15, 15, 16, 15, 15, 15, 15, 15, 15, 15, 15,15, 15, 15, 15, 15, 125, 15, 15},
			{16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16,16, 16, 16, 16, 126, 402, 16, 16} };
			//tamaño del texto
			tam = texto.Length;
			//While que recorre todo el texto escrito en la consola.
			while (i < tam)
			{
				//si el lexema contiene una nueva linea al principio de la verificacion se limpia para evitar errores
				if (lexema == "\n")
				{
					lexema = "";
				}
				//el caracter actual a analizar se toma de la consola usando el iterador i
				carac = texto[i];

				//condicion que sirve para que comentarios y cadenas permitan espacios vacios con una booleana
				if (carac == '\"' || carac == '\'')
				{
					cadena = true;
				}
				//switch para la booleana anteriormente mencionada
				switch (cadena)
				{
					//si se trata de una cadena o comentario no se cortan espacios extras y se añade el caracter al lexema
					case true:
						lexema += carac.ToString();
						break;
					//si no se trata de una cadena o comentario se cortan espacios extras con .Trim() y se añade el caracter al lexema
					case false:
						lexema += carac.ToString().Trim();
						break;
				}
				//se obtiene la columna para la matriz, dependiendo el caracter se regresa un numero.
				//esto siguiendo el quintuplo de excel.
				col = BuscarColumna(carac);
				//se obtiene el estado actual en la matriz con estado y columna
				estado = matriz[estado, col];
				//Si el estado es mayor o igual a 100 significa que podemos registrar el lexema.
				if (estado >= 100)
				{
					//Primero se verifica si el estado es un error
					if (estado >= 300)
					{
						//Si el error era causado por un espacio vacio se hace esta condicion 
						//para evitar registrar un lexema vacio y solo se limpia el estado y el lexema.
						if (lexema.ToString() == " " || lexema.ToString() == "")
						{
							estado = 0;
							lexema = "";
						}

						else
						{
							//DEPENDIENDO EL TIPO DE ERROR SE IMPRIME EN LA TABLA DE ERRORES
							//Y SE LIMPIAN VARIABLES
							if (estado == 300)
							{
								if (lexema.Contains("*") || lexema.Contains("+") || lexema.Contains("-") || lexema.Contains("/") || lexema.Contains(">") || lexema.Contains("<") || lexema.Contains(";") || lexema.Contains("=") || lexema.Contains("(") || lexema.Contains(")") || lexema.Contains(":"))
								{
									string auxiliar = "";
									for (int pos = 0; pos <= lexema.Length - 2; pos++)
									{
										auxiliar += lexema[pos].ToString();
									}
									estado = 0;
									lexema = "";
									cadena = false;
									i = i - 1;
								}
								else
								{
									estado = 0;
									lexema = "";
									cadena = false;
								}
							}
							else
							{
								if (estado == 301)
								{
									estado = 0;
									lexema = "";
									cadena = false;


								}
								else
								{
									estado = 0;
									lexema = "";
									cadena = false;

								}
							}
							error = true;
						}
					}
					//SI NO ES UN ERROR
					else
					{

						//Si el lexema contiene solo un caracter, este se registra sin problemas.
						if (lexema.Length == 1)
						{
							//Metodo de impresion, se repite mucho a lo largo del codigo.
							//Los datos se registran en la lista de token y se limpian variables.
							lexemalist.Add(lexema.Trim());
							tokenlist.Add("Token: " + estado);
							linealist.Add("linea: " + linea);
							estado = 0;
							lexema = "";
							cadena = false;
						}
						else
						{
							if (lexema.ToString() == "" || lexema.ToString() == " " || lexema.ToString() == "  ")
							{
								//condicion que verifica que el lexema no venga vacio, si esta vacio no
								//registra nada y se pasa a la siguiente vuelta del while.
							}
							else
							{
								//condicion que verifica si el lexema cuenta con ciertos simbolos
								//si los contiene se verifica si es necesario limpiar un simbolo que esté de más.
								if (lexema.Contains("*") || lexema.Contains("+") || lexema.Contains("-") || lexema.Contains("/") || lexema.Contains(">") || lexema.Contains("<") || lexema.Contains(";") || lexema.Contains("=") || lexema.Contains("(") || lexema.Contains(")") || lexema.Contains(":") || lexema.Contains(","))
								{
									//if que excluye a ciertos estados de ser limpiados ya que contienen simbolos pero no requiere limpieza
									if (estado == 127 || estado == 115 || estado == 117 || estado == 119 || estado == 115 || estado == 128 || estado == 126)
									{
										lexemalist.Add(lexema.Trim());
										tokenlist.Add("Token: " + estado);
										linealist.Add("linea: " + linea);
										estado = 0;
										lexema = "";
										cadena = false;
									}
									else
									{
										//Si es un numero exponencial y contiene un menos
										if (estado == 103 && lexema.Contains("-"))
										{
											//si el lexema contiene un punto y coma se hace la limpieza del ultimo caracter
											if (lexema.Contains(";"))
											{
												//este metodo lo explicare mas adelante.
												string auxiliar = "";
												for (int pos = 0; pos <= lexema.Length - 2; pos++)
												{
													auxiliar += lexema[pos].ToString();
												}
												for (int j = 0; j <= reservadas.Length - 1; j++)
												{
													if (auxiliar.Trim() == reservadas[j])
													{
														estado = 200 + j;
													}
												}
												lexemalist.Add(auxiliar.Trim());
												tokenlist.Add("Token: " + estado);
												linealist.Add("linea: " + linea);
												estado = 0;
												lexema = "";
												auxiliar = "";
												i = i - 1;
												cadena = false;
											}
											else
											{
												//si no existe un punto y coma no hace falta limpiar y se registra.
												lexemalist.Add(lexema.Trim());
												tokenlist.Add("Token: " + estado);
												linealist.Add("linea: " + linea);
												estado = 0;
												lexema = "";
												cadena = false;
											}
										}
										//Si es una palabra que requiere de limpieza 
										else
										{
											//se crea un auxiliar 
											string auxiliar = "";
											//este ciclo recorre el lexema hasta el penultimo caracter
											//y guarda caracter por caracter en el auxiliar
											//con esto se limpia el ultimo caracter del lexema
											for (int pos = 0; pos <= lexema.Length - 2; pos++)
											{
												auxiliar += lexema[pos].ToString();
											}
											//este segundo for busca si de casualidad 
											//el lexema contiene una palabra reservada
											//si es asi el token obtiene un nuevo valor para diferenciarlo.
											for (int j = 0; j <= reservadas.Length - 1; j++)
											{
												if (auxiliar.Trim() == reservadas[j])
												{
													estado = 200 + j;
												}
											}
											//al terminar se registran los datos y se limpian variables
											//Tambien se resta 1 al iterador para volver a evaluar el caracter que se
											//limpió
											lexemalist.Add(auxiliar.Trim());
											tokenlist.Add("Token: " + estado);
											linealist.Add("linea: " + linea);
											estado = 0;
											lexema = "";
											auxiliar = "";
											i = i - 1;
											cadena = false;
										}
									}
								}
								else
								{
									//SI NO SE REQUIERE LIMPIEZA SE HACE UNA SERIE DE 
									//VERIFICACIONES PARA ESTADOS NUMERICOS
									//SI SE LLEGO A UN ESTADO DE NUMERO ENTERO
									if (estado == 101)
									{
										//si de algun modo existe un punto en el lexema se forza pasar a estado 4
										//del automata (este estado es para numeros decimales) y no se registra
										if (lexema[lexema.Length - 1].ToString() == ".")
										{
											estado = 4;
										}
										//si de algun modo existe una e en el numero se apunta al estado 5
										//del automata (este estado es para numeros exponenciales) y no se registra
										if (lexema[lexema.Length - 1].ToString() == "e")
										{
											estado = 5;
										}
										else
										{
											//Si no existen detalles en el lexema se registra el dato sin problemas.
											if (estado >= 100)
											{
												lexemalist.Add(lexema.Trim());
												tokenlist.Add("Token: " + estado);
												linealist.Add("linea: " + linea);
												estado = 0;
												lexema = "";
												cadena = false;
											}
										}
									}
									else
									{
										//SI ES VARIABLE/TEXTO
										if (estado == 100)
										{
											//Se verifica rapidamente si la palabra es reservada con el mismo metodo
											//y se registra el lexema
											for (int j = 0; j <= reservadas.Length - 1; j++)
											{
												if (lexema.Trim() == reservadas[j])
												{
													estado = 200 + j;
												}
											}
											lexemalist.Add(lexema.Trim());
											tokenlist.Add("Token: " + estado);
											linealist.Add("linea: " + linea);
											estado = 0;
											lexema = "";
											cadena = false;
										}
										else
										{
											//Metodo que sirve para separar puntos al final de un numero
											//exponencial para limpiarlo y evitar un lexema incorrecto
											if (estado == 103 && lexema[lexema.Length - 1].ToString() == ".")
											{
												string auxiliar = "";
												for (int pos = 0; pos <= lexema.Length - 2; pos++)
												{
													auxiliar += lexema[pos].ToString();
												}
												//otro for por si la palabra era una reservada
												for (int j = 0; j <= reservadas.Length - 1; j++)
												{
													if (auxiliar.Trim() == reservadas[j])
													{
														estado = 200 + j;
													}
												}
												//al terminar se registran los datos y se limpian variables
												//Tambien se resta 1 al iterador para volver a evaluar el caracter que se
												//limpió
												lexemalist.Add(auxiliar.Trim());
												tokenlist.Add("Token: " + estado);
												linealist.Add("linea: " + linea);
												estado = 0;
												lexema = "";
												auxiliar = "";
												i = i - 1;
												cadena = false;
											}
											else
											{
												//Si se llega a esta condicion es porque no existe ningun error o detalle
												//con el lexema y se registra sin problemas
												lexemalist.Add(lexema.Trim());
												tokenlist.Add("Token: " + estado);
												linealist.Add("linea: " + linea);
												estado = 0;
												lexema = "";
												cadena = false;
											}
										}
									}
								}
							}
						}
					}
				}
				//casi al terminar el ciclo de while se verifica si el valor
				//que regresó la columna corresponde a un enter para aumentar la linea.
				if (col == 18)
				{
					linea++;
				}
				//se aumenta i para evaluar el siguiente caracter.
				i++;
			}
			//al terminar de compilar se reinician las variables
			i = 0;
			linea = 1;
			lexema = "";
		}
		private int BuscarColumna(char caracter)
		{
			char[] arrayCaracteres = { 'ñ', 'ñ', '_', '.', 'e', '+', '-', '*', '/', '<', '>', '=', '#', '(', ')', '[', ']', ',', ';', ':', '\'', 'ñ', ' ', 'ñ' };

			//revisamos si el carcater es una letra u sea diferente a la 'e' para saber que es una variable y no un exponencial y regresamos la columna 0
			if (char.IsLetter(caracter) && caracter != 'e')
				return 0;
			//en caso de que se reciva un numero regresamos la columna  
			else if (char.IsNumber(caracter))
				return 1;
			//revisamos que el caracter este dentro del arreglo, el -1 significa que no esta 
			else if (Array.IndexOf(arrayCaracteres, caracter) != -1)
				return Array.IndexOf(arrayCaracteres, caracter);
			//regresamos el indice del caracter
			else 
				return 21;
			//en caso de que no sea ninguno regresamos la columna 21
		}
	}
}
