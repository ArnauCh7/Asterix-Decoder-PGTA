using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Project2
{
    public class AsterixFile
    {
        string path;
        List<byte[]> messagesList = new List<byte[]>();
        List<BitArray> fspeclist = new List<BitArray>();

        public AsterixFile(string name)
        {
            this.path = name;//.ast file name
        }

        /// <summary>
        /// public Get function
        /// </summary>
        /// <returns> List of messages as byte arrays</returns>

        public List<byte[]> GetMessageList()
        {
            return this.messagesList;
        }

        /// <summary>
        /// public Get function
        /// </summary>
        /// <returns> List of FSPECs as BitArrays</returns>
        
        public List<BitArray> GetFspec()
        {
            return this.fspeclist;
        }


        /// <summary>
        /// Function that reads the file and returns a list of byte arrays, 
        /// each one containing an Asterix message
        /// </summary>
        public void read()
        {
            byte[] fileBytes = File.ReadAllBytes(path);//byte array which contains all bytes in the document
            List<byte[]> messagelist = new List<byte[]>(); //list of byte arrays where every item on the list is a separate Asterix message
            int i = 0; //while loop index
            int counter = fileBytes[2]; //LEN of the Asterix message

            while (i < fileBytes.Length)
            {
                byte[] bag = new byte[counter];//byte array with length = LEN of Asterix message
                for (int j = 0; j < bag.Length; j++)
                {
                    bag[j] = fileBytes[i]; //cerate an array with as much bytes as the message (LEN)
                    i++;
                }
                messagelist.Add(bag); //put the array created on the message list
                if (i+2 < fileBytes.Length)
                {
                    counter  = fileBytes[i+2];//change the counter to be the next LEN for the following message
                }
            }

            messagesList = messagelist;

        }
        

        /// <summary>
        /// Given a list of messages in byte arrays it extracts the FSPEC of 
        /// each message and arranges it into a list of string where 
        /// each of those is an FSPEC of a respective Asterix message
        /// </summary>
        /// <param name="messages"> Each byte array is an Asterix message</param>

        public void FSPEC(List<byte[]> messages)
        {
            List<BitArray> fspecList = new List<BitArray>();
            for (int i = 0; i < messages.Count; i++)
            {
                byte[] buff = messages[i];

                int j = 4;
                BitArray bitArray = new BitArray(new byte[] { buff[3] }); // Create a BitArray from buff[3]
                Reverse(bitArray);
                while (j < buff.Length)
                {
                    if (bitArray[bitArray.Length - 1] == true)
                    {
                        BitArray bitArraytoAppend = new BitArray(new byte[] { buff[j] }); // Create a BitArray from buff[j]
                        Reverse(bitArraytoAppend);
                        bitArray = ConcatenateBitArrays(bitArray, bitArraytoAppend);
                    }
                    else
                    {
                        j = buff.Length;
                    }

                    j++;
                }

                fspecList.Add(bitArray);

                this.fspeclist = fspecList;
            }
            // At this point, fspecList contains the list of BitArrays
        }

        /// <summary>
        /// Puts 2 BitArrays together in a 1 dimentional array
        /// </summary>
        /// <param name="first">BitArray that goes first</param>
        /// <param name="second">BitArray that goes behind the first one</param>
        /// <returns></returns>
        
        static BitArray ConcatenateBitArrays(BitArray first, BitArray second)
        {
            int length = first.Length + second.Length;
            BitArray result = new BitArray(length);

            for (int i = 0; i < first.Length; i++)
            {
                result[i] = first[i];
            }

            for (int i = 0; i < second.Length; i++)
            {
                result[i + first.Length] = second[i];
            }

            return result;
        }


        /// <summary>
        /// Reverses the input Bitarray
        /// </summary>
        /// <param name="array"></param>
        public void Reverse(BitArray array)
        {
            int length = array.Length;
            int mid = (length / 2);

            for (int i = 0; i < mid; i++)
            {
                bool bit = array[i];
                array[i] = array[length - i - 1];
                array[length - i - 1] = bit;
            }
        }


    }


}
