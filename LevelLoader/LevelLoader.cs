using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CSE3902Project.LevelLoader
{

    public class LevelLoader
    {
        string winDir = System.Environment.GetEnvironmentVariable("windir");

        public LevelLoader()
        {
            LoadXML();
        }

        /*
         * Stuff that needs to be in XML:
         * ---------------
         * Object types:
         *  Link
         *  Background
         *  Collideable wall
         *  Enemies
         * ---------------
         * Location
         * ---------------
         * Object Name
         * 
         */

        //Takes entire xml and sends each line to ParseLine
        //floor xml contains room xml files. seprate xml for rooms
        private void LoadXML()
        {
            StreamReader reader = new StreamReader(winDir + "\\system.ini");//filepath of xml file. Make name of level1.xml, level2.xml, level3.xml, etc. so you can make the filepath a variable
            try
            {
                do
                {
                    ParseLine(reader.ReadLine());//test it by printing every line
                }
                while (reader.Peek() != -1);
            }
            catch
            {
                ParseLine("File is empty");//can remove this
            }
            finally
            {
                reader.Close();
            }
        }

        //Deals with individual lines of xml in string format
        //line will have obj type, location, and 
        private void ParseLine(string line)
        {
            //Determine what object type it is and tells sprite factory
            //tells game object manager where to put the sprite it got from factory, do not make levelLoader the GOM
            //GOM puts sprites where they need to go
        }

        //Separate methods to parse each thing?
        
        //will build a room and return a room object?
        private void BuildRoom()
        {

        }
    }
}
