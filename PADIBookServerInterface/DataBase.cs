using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using PADIBook.Utils;

namespace PADIBook.Server.DB
{
    public delegate void WriteDataBaseDelegate();

    public sealed class DataBase
    {
        private string dbName;
        private string dbFolder;
        private Dictionary<string, Entity> dataBase;
        private readonly static object dbLock = new object();

        public string DataBaseName
        {
            get
            {
                return Path.Combine(dbFolder, dbName);
            }
        }

        public DataBase(string folder, string dbname)
        {
            dbName = dbname;
            dbFolder = folder;

            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            Stream dbStream = null;
            try
            {
                dbStream = File.Open(Path.Combine(dbFolder, dbName), FileMode.Open);
                BinaryFormatter bFormatter = new BinaryFormatter();
                dataBase = (Dictionary<string, Entity>)bFormatter.Deserialize(dbStream);
            }
            catch (FileNotFoundException)
            {
                if (dbStream != null)
                    dbStream.Close();
                dbStream = File.Open(Path.Combine(dbFolder, dbName), FileMode.Create);
                dataBase = new Dictionary<string, Entity>();
            }
            catch (SerializationException)
            {
                if (dbStream != null)
                    dbStream.Close();
                dbStream = File.Open(Path.Combine(dbFolder, dbName), FileMode.Create);
                dataBase = new Dictionary<string, Entity>();
            }
            finally
            {
                if (dbStream != null)
                    dbStream.Close();
            }
            WriteDataBaseDelegate += new WriteDataBaseDelegate(FlushDataBase);
        }

        private WriteDataBaseDelegate writeDel;
        public event WriteDataBaseDelegate WriteDataBaseDelegate
        {
            add { writeDel += value; }
            remove
            {
                if (writeDel != null)
                    writeDel -= value;
            }
        }

        public void AddEntity(Entity entity)
        {
            lock (dbLock)
            {
                try
                {
                    dataBase.Add(entity.Value.ID, entity);
                }
                catch (ArgumentException)
                {
                    dataBase.Remove(entity.Value.ID);
                    dataBase.Add(entity.Value.ID, entity);
                }
                writeDel();
            }
        }

        public Entity GetEntity(string id)
        {
            Entity entity;
            bool getValue;
            lock (dbLock)
            {
                getValue = dataBase.TryGetValue(id, out entity);
            }
            if (getValue == true)
                return entity;
            return null;
        }

        private void FlushDataBase()
        {
            Stream stream = File.Open(Path.Combine(dbFolder, dbName), FileMode.Create);
            new BinaryFormatter().Serialize(stream, dataBase);
            stream.Flush();
            stream.Close();
        }

        public void Close()
        {
            FlushDataBase();
        }
    }
}
