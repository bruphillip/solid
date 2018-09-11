using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;

namespace AulaSolid
{
	class Program
    {
        static Container container;
        static void Main(string[] args)
        {

            // Configura dependencia
            ConfigureDependecy();

            IPartinerRepository repository = container.GetInstance<IPartinerRepository>();

            //1 - APLICAR: SINGLE RESPONSABILITY PRINCIPLE
            //2 - APLICAR: OPEN CLOSED PRINCIPLE
            //3 - APLICAR: LISKOV SUBSTITUTION PRINCIPLE
            //4 - APLICAR: INTERFACE SEGREGATION PRINCIPLE
            //5 - APLICAR: DEPENDENCY INVERSION PRINCIPLE            
            //KISS / YAGNY / DRY
            Console.Write("E-mail para inscrição: ");
            string email = Console.ReadLine();
            Console.Write("Nome da inscrição: ");
            string nome = Console.ReadLine();

            Partiner partiner = new Partiner(nome, email);
            repository.Insert(partiner);


            Console.Write("Rebecer notificação por (1-Email / 2-Tela): ");
            int notificacao = Convert.ToInt32(Console.ReadLine());

            if (notificacao == 1)
            {
                var mail = new MailMessage("empresa@empresa.com", email);

                var client = new SmtpClient
                {
                    Port = 25,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Host = "smtp.google.com"
                };

                mail.Subject = "Bem Vindo, " + nome;
                mail.Body = "Parabéns! Você está cadastrado.";
                client.Send(mail);
            }
            else if (notificacao == 2)
            {
                Console.WriteLine("Bem Vindo, " + nome);
                Console.WriteLine("Parabéns! Você está cadastrado.");
            }
            else if (notificacao == 3)
            {
                //SMS MESSAGE
                //NUMERO CELULAR, MENSAGEM, TITULO
            }

            Console.WriteLine("Cliente cadastrado com sucesso!");

            Console.WriteLine("Lista de Clientes cadastrados");
            ShowPartiners(repository.GetAll());

           
            Console.WriteLine("Exportar Clientes cadastrados");
            ShowPartiners(repository.GetAll());

            Console.ReadKey();
        }

        private static void ShowPartiners(List<Partiner> listPartiner)
        {

            foreach (var item in listPartiner)
            {
                Console.WriteLine("ID: " + item.PartinerId + " - NOME: " + item.Nome + " - EMAIL: " + item.Email);

            }
        }

        private static void ConfigureDependecy()
        {
            // 1. Create a new Simple Injector container
            container = new Container();

            // 2. Configure the container (register)
            container.Register<IPartinerRepository, PartinerRepository>();

            // 3. Verify your configuration
            container.Verify();
        }
    }
}