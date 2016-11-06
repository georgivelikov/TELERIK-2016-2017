using System.IO;
using System.Xml;

namespace Task07
{
    public class Start
    {
        public static void Main()
        { 
            var doc = new XmlDocument();
            var peopleHolder = doc.CreateElement("people");
            doc.AppendChild(peopleHolder);

            var path = "../../personsDb.txt";
            var reader = new StreamReader(path);
            using (reader)
            {
                var counter = 0;
                var name = string.Empty;
                var address = string.Empty;
                var phone = string.Empty;

                var line = reader.ReadLine();
                while (line != null)
                {                   
                    switch (counter)
                    {
                        case 0:
                            name = line;
                            break;
                        case 1:
                            address = line;
                            break;
                        case 2:
                            phone = line;
                            break;
                    }

                    if (counter == 2)
                    {
                        counter = 0;
                        var person = doc.CreateElement("person");
                        peopleHolder.AppendChild(person);

                        var nameEl = doc.CreateElement("name");
                        nameEl.InnerText = name;
                        person.AppendChild(nameEl);

                        var addressEl = doc.CreateElement("address");
                        addressEl.InnerText = address;
                        person.AppendChild(addressEl);

                        var phoneEl = doc.CreateElement("phone");
                        phoneEl.InnerText = phone;
                        person.AppendChild(phoneEl);
                    }
                    else
                    {
                        counter++;
                    }

                    line = reader.ReadLine();
                }
            }

            var savePath = "../../people.xml";
            doc.Save(savePath);

        }
    }
}
