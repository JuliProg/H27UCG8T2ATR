using NAND_Prog;
using System;
using System.ComponentModel.Composition;

namespace H27UCG8T2ATR
{
    /*
     use the design :

      # region
         <some code>
      # endregion

    for automatically include <some code> in the READMY.md file in the repository
    */
   
    
   
    public class ChipAssembly
    {
        [Export("Chip")]
        ChipPrototype myChip = new ChipPrototype();



        #region Chip parameters

        //--------------Warning!!!!!!!!!!!!!!!-------------------------------------------
        //
        //   The first operation must be a command
        //   Reset  !!!
        //
        //--------------------Vendor Specific Pin configuration---------------------------

        //  VSP1(38pin) - NC    
        //  VSP2(35pin) - NC
        //  VSP3(20pin) - NC

        ChipAssembly()
        {
            myChip.devManuf = "Hynix";
            myChip.name = "H27UCG8T2ATR";
            myChip.chipID = "ADDE94DA74C4";      // device ID

            myChip.width = Organization.x8;    // chip width - 8 bit
            myChip.bytesPP = 16384;             // page size in bytes
            myChip.spareBytesPP = 1280;          // size Spare Area in bytes
            myChip.pagesPB = 256;               // the number of pages per block 
            myChip.bloksPLUN = 2132;           // number of blocks in CE
            myChip.LUNs = 1;                   // the amount of CE in the chip
            myChip.colAdrCycles = 2;           // cycles for column addressing
            myChip.rowAdrCycles = 3;           // cycles for row addressing 
            myChip.vcc = Vcc.v3_3;             // supply voltage
           // myChip.EccBits = 20;
            #endregion


            #region Chip operations

            //------- Add chip operations    https://github.com/JuliProg/Wiki#command-set----------------------------------------------------

            myChip.Operations("Reset_FFh").
                   Operations("Erase_60h_D0h").
                   Operations("Read_00h_30h").
                   Operations("PageProgram_80h_10h");

            #endregion



            #region Chip registers (optional)

            //------- Add chip registers (optional)----------------------------------------------------

            myChip.registers.Add(                   // https://github.com/JuliProg/Wiki/wiki/StatusRegister
                "Status Register").
                Size(1).
                Operations("ReadStatus_70h").
                Interpretation("SR_Interpreted").
                UseAsStatusRegister();



            myChip.registers.Add(                  // https://github.com/JuliProg/Wiki/wiki/ID-Register
                "Id Register").
                Size(6).
                Operations("ReadId_90h");
            

        

            #endregion


        }

       
    }

}
