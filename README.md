# Swedish Bank ID sample (.NET 6, Bank ID v5)

Built and assembled from various docs and samples online.

Covers:

* Authentication
* Signing
* Validation (currently only signature, BankID edvice 6 step process here: https://www.bankid.com/en/utvecklare/guider/teknisk-integrationsguide/verifiera-signaturer)

NOT any form of production-grade code, simple POC only ;).

Bank ID API docs: https://www.bankid.com/utvecklare/guider/teknisk-integrationsguide/webbservice-api

Bank ID Guides: https://www.bankid.com/utvecklare/guider

Bank ID Xml Signature doc: https://docs.zignsec.com/wp-content/uploads/2018/05/BankID_SignatureProfile_v238004.pdf

Bank ID Autostart / launching docs: https://www.bankid.com/utvecklare/guider/teknisk-integrationsguide/programstart

Bank ID QR code docs: https://www.bankid.com/utvecklare/guider/teknisk-integrationsguide/qrkoder

### File signing

Bank ID Advice here: https://www.bankid.com/en/utvecklare/guider/teknisk-integrationsguide/filsignering

In essence:
1. Show document to user.
2. Compute checksum / digest.
3. Compile document abstract of document content.
4. Sign witrh uservisibledata that contain the abstract.
5. UserNonVisibleData contains digest/checksum.

## Install and setup Bank ID client for test use.

1. Download bankid client from this link: https://install.bankid.com/FileDownloader?fileId=Win
2. Install the bankid client.
3. Close bankid and open the %appdata%\BankID\Config folder. Create a plain text file named ”CavaServerSelector.txt”, containing the text ”kundtest”. 
   The content must be plain text and lower case.
4. Log in to https://demo.bankid.com/.
5. Issue new local bankid certificate, add password.


### Get client test certificate

Download certificate from https://www.bankid.com/assets/bankid/rp/FPTestcert3_20200618.p12 (https://www.bankid.com/utvecklare/test) (included in project).


