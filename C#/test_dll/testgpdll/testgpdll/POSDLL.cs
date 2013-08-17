using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace testgpdll
{
    class POSDLL
    {
        [DllImport("POSDLL.dll")]
        public static extern IntPtr POS_Open(
                                    string lpName,
                                    int nComBaudrate,
                                    int nComDataBits,
                                    int nComStopBits,
                                    int nComParity,
                                    int nParam
                                    );

        [DllImport("POSDLL.dll")]
        public static extern int POS_Close();

        [DllImport("POSDLL.dll")]
        public static extern int POS_StartDoc();

        [DllImport("POSDLL.dll")]
        public static extern int POS_WriteFile(
                                    IntPtr hPort,
                                    byte[] pszData,
                                    int nBytesToWrite
                                    );

        [DllImport("POSDLL.dll")]
        public static extern int POS_EndDoc();

        [DllImport("POSDLL.dll")]
        public static extern int POS_Reset();

        [DllImport("POSDLL.dll")]
        public static extern int POS_SetMode(
                                    int nPrintMode
                                    );

        [DllImport("POSDLL.dll")]
        public static extern int POS_SetMotionUnit(

int nHorizontalMU,

int nVerticalMU

      );



        [DllImport("POSDLL.dll")]
        public static extern int POS_SetCharSetAndCodePage(

      int nCharSet,

      int nCodePage

      );

        [DllImport("POSDLL.dll")]
        public static extern int POS_FeedLine();

        [DllImport("POSDLL.dll")]
        public static extern int POS_SetLineSpacing(

      int nDistance

      );



        [DllImport("POSDLL.dll")]
        public static extern int POS_SetRightSpacing(

      int nDistance

      );

        [DllImport("POSDLL.dll")]
        public static extern int POS_PreDownloadBmpToRAM(

      string pszPath,

      int nID

      );

        [DllImport("POSDLL.dll")]
        public static extern int POS_PreDownloadBmpsToFlash(

      string[] pszPaths,

      int nCount

      );

        [DllImport("POSDLL.dll")]
        public static extern int POS_QueryStatus(

     byte[] pszStatus,

  int nTimeouts

      );

        [DllImport("POSDLL.dll")]
        public static extern int POS_RTQueryStatus(

      byte[] pszStatus

      );

        [DllImport("POSDLL.dll")]
        public static extern int POS_KickOutDrawer(

int nID,

int nOnTimes,

int nOffTimes

      );

        [DllImport("POSDLL.dll")]
        public static extern int POS_CutPaper(

int nMode,

int nDistance

) ;

        [DllImport("POSDLL.dll")]
        public static extern int POS_S_SetAreaWidth(

      int nWidth

      ) ;

        [DllImport("POSDLL.dll")]
        public static extern int POS_S_TextOut(

      string pszString,

      int nOrgx,

      int nWidthTimes,

      int nHeightTimes,

      int nFontType,

      int nFontStyle

      );

        [DllImport("POSDLL.dll")]
        public static extern int POS_S_DownloadAndPrintBmp(

      string pszPath,

      int nOrgx,

      int nMode

      );

        [DllImport("POSDLL.dll")]
        public static extern int POS_S_PrintBmpInRAM(

      int nID,

      int nOrgx,

      int nMode

      );


        [DllImport("POSDLL.dll")]
        public static extern int POS_S_PrintBmpInFlash(

      int nID,

      int nOrgx,

      int nMode

      );

        [DllImport("POSDLL.dll")]
        public static extern int POS_S_SetBarcode(

      string pszInfoBuffer,

      int nOrgx,

      int nType,

      int nWidthX,

      int nHeight,

      int nHriFontType,

      int nHriFontPosition,

      int nBytesToPrint

      );

        [DllImport("POSDLL.dll")]
        public static extern int POS_PL_SetArea(

      int nOrgx,

      int nOrgy,

      int nWidth,

      int nHeight,

      int nDirection

      );

        [DllImport("POSDLL.dll")]
        public static extern int POS_PL_TextOut(

      string pszString,

      int nOrgx,

      int nOrgy,

      int nWidthTimes,

      int nHeightTimes,

      int nFontType,

      int nFontStyle

      );

        [DllImport("POSDLL.dll")]
        public static extern int POS_PL_DownloadAndPrintBmp(

      string pszPath,

      int nOrgx,

      int nOrgy,

      int nMode

      );

        [DllImport("POSDLL.dll")]
        public static extern int POS_PL_PrintBmpInRAM(

      int nID,

      int nOrgx,

      int nOrgy,

      int nMode

      );

        [DllImport("POSDLL.dll")]
        public static extern int POS_PL_SetBarcode(

      string pszInfoBuffer,

      int nOrgx,

      int nOrgy,

      int nType,

      int nWidthX,

      int nHeight,

      int nHriFontType,

      int nHriFontPosition,

      int nBytesToPrint

      );

        [DllImport("POSDLL.dll")]
        public static extern int POS_PL_Print();

        [DllImport("POSDLL.dll")]
        public static extern int POS_PL_Clear();
    }
}
