# Swedish Bank ID sample (.NET 6)

Built and assembled from various docs and samples online.

## Install and setup Bank ID client for test use.

[https://www.bankid.com/utvecklare/guider]
[https://www.bankid.com/utvecklare/guider/teknisk-integrationsguide/webbservice-api]

1. Download bankid client from this link: https://install.bankid.com/FileDownloader?fileId=Win
2. Install the bankid client.
3. Close bankid and open the %appdata%\BankID\Config folder. Create a plain text file named ”CavaServerSelector.txt”, containing the text ”kundtest”. 
   The content must be plain text and lower case.
4. Log in to https://demo.bankid.com/.
5. Issue new local bankid certificate, add password.


### Get client test certificate

Download certificate from https://www.bankid.com/assets/bankid/rp/FPTestcert3_20200618.p12 (https://www.bankid.com/utvecklare/test) (included in project).


