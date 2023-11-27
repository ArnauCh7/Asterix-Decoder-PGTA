using proyecto;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Project2
{
    public class Data
    {
        List<List<byte[]>> dataFieldDivide = new List<List<byte[]>> { new List<byte[]>() };
        List<BitArray> FspecList = new List<BitArray>();

        public List<List<byte[]>> GetDividedDataFields()
        {
            return this.dataFieldDivide;
        }
        public List<BitArray>  GetFspecList()
        {
            return this.FspecList;
        }

        public List<List<byte[]>> SortData(Flight Flights, AsterixFile newfile)
        {
            newfile.read();
            List<byte[]> MessageList =  newfile.GetMessageList();
            newfile.FSPEC(newfile.GetMessageList());
            FspecList = newfile.GetFspec();

            int i = 0; // Message number
            List<List<byte[]>> dataFieldDivide = new List<List<byte[]>> { new List<byte[]>() };
            foreach(BitArray fspec in FspecList)
            {
                //Create a list of byte arrays for each message
                List<byte[]> message = new List<byte[]>();


                //Checking how long is the FSPEC
                int messageIndex;
                if(fspec.Length == 8){ messageIndex = 4;}
                else if(fspec.Length == 16) { messageIndex = 5;}
                else if(fspec.Length == 24) {  messageIndex = 6;}
                else {  messageIndex = 7;}

                //I048/010 Data Source Identifier (2 octets)
                if (fspec[0])
                {
                    int len = 2; //Length of the DataItem in bytes
                    byte[] data = new byte[len];// Create an array to store the bytes that will contain that DataItem
                    Array.Copy(MessageList[i], messageIndex, data, 0, len); // Copy thatentire dataItem to the new array that we just created from the message list we got from reading the file
                    message.Add(data);//Add this dataItem to the List<byte[]> that is message
                    messageIndex += len;//Increase the message index to select the next DataItem next time it is used
                }

                //I048/140 Time-of-Day (3 octets)
                if (fspec[1])
                {
                    int len = 3; 
                    byte[] data = new byte[len];
                    Array.Copy(MessageList[i], messageIndex, data, 0, len);
                    message.Add(data);
                    messageIndex += len;
                }

                //I048/020 Target Report Descriptor
                if (fspec[2])
                {
                    int initialMessageIndex = messageIndex;
                    bool extent = true;
                    while (extent)
                    {
                        BitArray bits = new BitArray(new byte[] { MessageList[i][messageIndex] });
                        newfile.Reverse(bits);
                        if (bits[bits.Length - 1])
                        {
                            
                            messageIndex++;
                        }
                        else
                        {
                            messageIndex++;
                            extent = false;
                        }
                    }
                    int octetCount = messageIndex - initialMessageIndex;
                    byte[] data = new byte[octetCount];
                    Array.Copy(MessageList[i], initialMessageIndex, data, 0, octetCount);
                    message.Add(data);
                }

                //I048/040 Measured Position in Slant Polar Coordinates
                if (fspec[3])
                {
                    int len = 4; 
                    byte[] data = new byte[len]; 
                    Array.Copy(MessageList[i], messageIndex, data, 0, len); 
                    message.Add(data);
                    messageIndex += len;
                }

                //I048/070 Mode-3/A Code in Octal Representation
                if (fspec[4])
                {
                    int len = 2; 
                    byte[] data = new byte[len];
                    Array.Copy(MessageList[i], messageIndex, data, 0, len);
                    message.Add(data);
                    messageIndex += len;
                }

                //I048/090 Flight Level in Binary Representation
                if (fspec[5])
                {
                    int len = 2; 
                    byte[] data = new byte[len];
                    Array.Copy(MessageList[i], messageIndex, data, 0, len);
                    message.Add(data);
                    messageIndex += len;
                }

                //I048/130 Radar Plot Characteristics
                if (fspec[6])
                {
                    int len = 1;
                    BitArray bits = new BitArray(new byte[] { MessageList[i][messageIndex] });
                    newfile.Reverse(bits);
                    if (bits[0]) len++;
                    if (bits[1]) len++;
                    if (bits[2]) len++;
                    if (bits[3]) len++;
                    if (bits[4]) len++;
                    if (bits[5]) len++;
                    if (bits[6]) len++;
                    if (bits[7]) len++;

                    byte[] data = new byte[len];
                    Array.Copy(MessageList[i], messageIndex, data, 0, len);
                    message.Add(data);
                    messageIndex += len;

                    
                }

                //If the FSPEC is bigger that 8 the following will exist
                if (fspec.Length > 8)
                {
                    //I048/220 Aircraft Adress
                    if (fspec[8])
                    {
                        int len = 3;
                        byte[] data = new byte[len];
                        Array.Copy(MessageList[i], messageIndex, data, 0, len);
                        message.Add(data);
                        messageIndex += len;
                    }

                    //I048/240 Aircraft Identification
                    if (fspec[9])
                    {
                        int len = 6;
                        byte[] data = new byte[len];
                        Array.Copy(MessageList[i], messageIndex, data, 0, len);
                        message.Add(data);
                        messageIndex += len;
                    }

                    //I048/250 Mode S MB Data
                    if (fspec[10])
                    {
                        int rep = MessageList[i][messageIndex];
                        int len = 1 + 8 * rep;
                        byte[] data = new byte[len];
                        Array.Copy(MessageList[i], messageIndex, data, 0, len);
                        message.Add(data);
                        messageIndex += len;

                    }

                    //I048/161 Track number
                    if (fspec[11])
                    {
                        int len = 2;
                        byte[] data = new byte[len];
                        Array.Copy(MessageList[i], messageIndex, data, 0, len);
                        message.Add(data);
                        messageIndex += len;
                    }

                    //I048/042 Calculated Position in Cartesian Cordinates
                    if (fspec[12])
                    {
                        int len = 4;
                        byte[] data = new byte[len];
                        Array.Copy(MessageList[i], messageIndex, data, 0, len);
                        message.Add(data);
                        messageIndex += len;
                    }

                    //I048/200 Calculated Track Velocity in Polar Representation
                    if (fspec[13])
                    {
                        int len = 4;
                        byte[] data = new byte[len];
                        Array.Copy(MessageList[i], messageIndex, data, 0, len);
                        message.Add(data);
                        messageIndex += len;
                    }


                    //I048/170 Track Status
                    if (fspec[14])
                    {
                        int initialMessageIndex = messageIndex;
                        bool extent = true;
                        while (extent)
                        {
                            BitArray bits = new BitArray(new byte[] { MessageList[i][messageIndex] });
                            newfile.Reverse(bits);
                            if (bits[bits.Length - 1])
                            {

                                messageIndex++;
                            }
                            else
                            {
                                messageIndex++;
                                extent = false;
                            }
                        }
                        int octetCount = messageIndex - initialMessageIndex;
                        byte[] data = new byte[octetCount];
                        Array.Copy(MessageList[i], initialMessageIndex, data, 0, octetCount);
                        message.Add(data);
                    }

                    //If the FSPEC is bigger that 16 the following will exist
                    if (fspec.Length > 16)
                    {
                        //I048/210 Track Quality (DO NOT ADD TO THE MESSAGE)
                        if (fspec[16])
                        {
                            int len = 4;
                            messageIndex += len;
                        }

                        //I048/030 Warning/Error Conditions/Target Classification (DO NOT ADD TO THE MESSAGE)
                        if (fspec[17])
                        {
                            int initialMessageIndex = messageIndex;
                            bool extent = true;
                            while (extent)
                            {
                                BitArray bits = new BitArray(new byte[] { MessageList[i][messageIndex] });
                                newfile.Reverse(bits);
                                if (bits[bits.Length - 1])
                                {

                                    messageIndex++;
                                }
                                else
                                {
                                    messageIndex++;
                                    extent = false;
                                }
                            }
                        }

                        //I048/080 Mode-3/A Code Confidence Indicator (DO NOT ADD TO THE MESSAGE)
                        if (fspec[18])
                        {
                            int len = 2;
                            messageIndex += len;
                        }

                        //I048/100 Mode-C Code and Confidence Indicator (DO NOT ADD TO THE MESSAGE)
                        if (fspec[19])
                        {
                            int len = 4;
                            messageIndex += len;
                        }

                        //I048/110 Height Mesured by 3D Radar
                        if (fspec[20])
                        {
                            int len = 2;
                            byte[] data = new byte[len];
                            Array.Copy(MessageList[i], messageIndex, data, 0, len);
                            message.Add(data);
                            messageIndex += len;
                        }


                        //I048/120 Radial Doppler Speed (DO NOT ADD TO THE MESSAGE)
                        if (fspec[21])
                        {
                            messageIndex++;
                        }

                        //I048/230 Communications / ACAS Capability and Flight Status
                        if (fspec[22])
                        {
                            int len = 2;
                            byte[] data = new byte[len];
                            Array.Copy(MessageList[i], messageIndex, data, 0, len);
                            message.Add(data);
                            messageIndex += len;
                        }

                        //If the FSPEC is bigger that 24 the following will exist
                        if (fspec.Length > 24)
                        {
                            //I048/260 ACAS Resolution Advisory Report (DO NOT ADD TO THE MESSAGE)
                            if (fspec[24])
                            {
                                int len = 7;
                                messageIndex += len;
                            }

                            //I048/055 Mode-1 Code in Octal Representation (DO NOT ADD TO THE MESSAGE)
                            if (fspec[25])
                            {
                                int len = 1;
                                messageIndex += len;
                            }

                            //I048/050 Mode-2 Code in Octal Representation (DO NOT ADD TO THE MESSAGE)
                            if (fspec[26])
                            {
                                int len = 2;
                                messageIndex += len;
                            }

                            //I048/065 Mode-1 Code Confidence Indicator (DO NOT ADD TO THE MESSAGE)
                            if (fspec[27])
                            {
                                int len = 1;
                                messageIndex += len;
                            }

                            //I048/060 Mode-2 Code Confidence Indicator (DO NOT ADD TO THE MESSAGE)
                            if (fspec[28])
                            {
                                int len = 2;
                                messageIndex += len;
                            }

                            //SP-Data Item Special Purpose Field
                            // TODO: Preguntar a Alex si lo usa
                            if (fspec[29])
                            {

                            }

                            //RE-Data Item Reserved Expansion Field
                            // TODO: Preguntar a Alex si lo usa
                            if (fspec[30])
                            {

                            }
                        }
                        
                    }
                    
                    
                }

                dataFieldDivide.Add(message);
                i++;
            }

            dataFieldDivide.RemoveAt(0);

            //Flights.Set_Message_Values(dataFieldDivide, FspecList);

            
            return dataFieldDivide;
        }

    }
}
