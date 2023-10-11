using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab15Ex
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> Studenti = new List<Student>();


            var student1 = new Student
            {
                Nume = "Avram",
                Prenume = "Alex",
                Varsta = 25,
                Specializare = Specializare.Infromatica

            };
            var student2 = new Student
            {
                Nume = "Matei",
                Prenume = "Adi",
                Varsta = 25,
                Specializare = Specializare.Infromatica

            };
            var student3 = new Student
            {
                Nume = "Ungur",
                Prenume = "Alex",
                Varsta = 40,
                Specializare = Specializare.Constructii

            };
            var student4 = new Student
            {
                Nume = "Bejan",
                Prenume = "Andrei",
                Varsta = 40,
                Specializare = Specializare.Constructii

            };
            var student5 = new Student
            {
                Nume = "Calugar",
                Prenume = "Alex",
                Varsta = 40,
                Specializare = Specializare.Litere

            };

            var student6 = new Student
            {
                Nume = "Mocan",
                Prenume = "Flaviu",
                Varsta = 22,
                Specializare = Specializare.Litere

            };
            var student7 = new Student
            {
                Nume = "Alex",
                Prenume = "Avram",
                Varsta = 22,
                Specializare = Specializare.Litere

            };
            var student8 = new Student
            {
                Nume = "Cartof",
                Prenume = "Malciu",
                Varsta = 18,
                Specializare = Specializare.Litere

            };
            Studenti.Add(student1);
            Studenti.Add(student2);
            Studenti.Add(student3);
            Studenti.Add(student4);
            Studenti.Add(student5);
            Studenti.Add(student6);
            Studenti.Add(student7);
            Studenti.Add(student8);
            Console.WriteLine(" Afisati cel mai in varsta student de laInformatica : ");
            var celMaiBatran = Studenti
                .Where(s => s.Specializare == Specializare.Infromatica)
                .OrderBy(s => s.Varsta)
                .LastOrDefault();
            Console.WriteLine(celMaiBatran);
            Console.WriteLine("Afisati cel mai tanar student:");
            var celMaiTanar = Studenti
                .OrderBy(s => s.Varsta)
                .FirstOrDefault();

            Console.WriteLine(celMaiTanar);
            Console.WriteLine(Studenti.FirstOrDefault(s => s.Varsta == Studenti.Min(s => s.Varsta)));

            Console.WriteLine("Afisati in ordine crescatoare a varstei toti,studentii de la litere:");
            Studenti
                .FindAll(s => s.Specializare == Specializare.Litere)
                .OrderBy(s => s.Varsta)
                .ToList()
                .ForEach(s => Console.WriteLine(s));
            Console.WriteLine("Afisati primul student de la constructii cuvarsta de peste 20 de ani:");
            Console.WriteLine(
                Studenti
                  .Where(s => s.Varsta > 20 && s.Specializare == Specializare.Constructii)

                  .FirstOrDefault()); ;

            /**/


            var varstaMedie = Studenti.Average(s => s.Varsta) / Studenti.Count;
            Console.WriteLine(varstaMedie);


            Console.WriteLine("Afisati studentii avand varsta egala cu varsta medie a studentilor:");
            Studenti.FindAll(s => s.Varsta == Studenti.Sum(s => s.Varsta) / Studenti.Count).ForEach(s => Console.WriteLine(s));

            Console.WriteLine("Afisati, in ordinea descrescatoare a varstei,si in ordine alfabetica, dupa numele defamilie si dupa numele mic, toti studentiicu varsta cuprinsa intre 18 si 35 de ani:");
            Studenti
                .Where(s => s.Varsta >= 18 && s.Varsta <= 35)
                .OrderByDescending(s => s.Varsta)
                .ThenBy(s => s.Nume)
                .ThenBy(s => s.Prenume)
                .ToList()
                .ForEach(s => Console.WriteLine(s));
            Console.WriteLine(". Afisati mesajul “Exista si minori” daca in listacreeata exista si persone cu varsta mai mica de18 ani.In caz contar afesati “Nu exista minori:");
            if (Studenti.Any(s => s.Varsta < 18))
            {
                Console.WriteLine("Exista si minori");
            }
            else
            {
                Console.WriteLine("Nu Exista minori");
            }

            var results = Studenti
                .GroupBy(s => s.Varsta);


            foreach (var group in results)
            {
                Console.WriteLine($"Sutdenti cu varsta de {group.Key}:");
                foreach (var student in group)
                {
                    Console.WriteLine(student);
                }
            }

            //SAUUUUU LINQQQQ  SONDA LAMBDA

            Studenti.GroupBy(s => s.Varsta)
                .ToList().ForEach(s => { Console.WriteLine(s.Key);
                    s.ToList().ForEach(s => Console.WriteLine(s));


                });
            //Grou by dupa mai multe criterii:
            var ageMajorGroups = Studenti.GroupBy(s => new { s.Varsta, s.Specializare });
            foreach (var group in ageMajorGroups)
            {
                var key = group.Key;
                Console.WriteLine($"Studentii de la {key.Specializare} cu varsta {key.Varsta}");
                foreach (var student in group)
                {
                    Console.WriteLine(student);
                }
            }

            Studenti.OrderBy(s => s.Varsta).Select(s => new
            {
                Nume = $"{s.Nume} {s.Prenume}",
                s.Varsta// sintaxa corecta e Varsta = s.Varsta dar se prinde compilatorul
            }


            ).ToList().ForEach(p =>
            {
                Console.WriteLine(p.Varsta);
                Console.WriteLine(p.Nume);
            }); 

        }


        class Student
        {
            public Guid Id { get; private set; } = Guid.NewGuid();
            public string Nume { get; set; }
            public string Prenume { get; set; }
            public int Varsta { get; set; }
            public Specializare Specializare { get; set; }

            public override string ToString()
            {
                return $"Elevul {Nume} {Prenume} are {Varsta} ani si este inscris la specializarea {Specializare} ";
            }


        }

        enum Specializare
        {
            Infromatica,
            Litere,
            Constructii
        }
    }
}
