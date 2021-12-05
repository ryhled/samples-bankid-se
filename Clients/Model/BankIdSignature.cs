
// NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.w3.org/2000/09/xmldsig#")]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
public partial class Signature
{

    private SignatureSignedInfo signedInfoField;

    private string signatureValueField;

    private SignatureKeyInfo keyInfoField;

    private SignatureObject objectField;

    /// <remarks/>
    public SignatureSignedInfo SignedInfo
    {
        get
        {
            return this.signedInfoField;
        }
        set
        {
            this.signedInfoField = value;
        }
    }

    /// <remarks/>
    public string SignatureValue
    {
        get
        {
            return this.signatureValueField;
        }
        set
        {
            this.signatureValueField = value;
        }
    }

    /// <remarks/>
    public SignatureKeyInfo KeyInfo
    {
        get
        {
            return this.keyInfoField;
        }
        set
        {
            this.keyInfoField = value;
        }
    }

    /// <remarks/>
    public SignatureObject Object
    {
        get
        {
            return this.objectField;
        }
        set
        {
            this.objectField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.w3.org/2000/09/xmldsig#")]
public partial class SignatureSignedInfo
{

    private SignatureSignedInfoCanonicalizationMethod canonicalizationMethodField;

    private SignatureSignedInfoSignatureMethod signatureMethodField;

    private SignatureSignedInfoReference[] referenceField;

    /// <remarks/>
    public SignatureSignedInfoCanonicalizationMethod CanonicalizationMethod
    {
        get
        {
            return this.canonicalizationMethodField;
        }
        set
        {
            this.canonicalizationMethodField = value;
        }
    }

    /// <remarks/>
    public SignatureSignedInfoSignatureMethod SignatureMethod
    {
        get
        {
            return this.signatureMethodField;
        }
        set
        {
            this.signatureMethodField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Reference")]
    public SignatureSignedInfoReference[] Reference
    {
        get
        {
            return this.referenceField;
        }
        set
        {
            this.referenceField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.w3.org/2000/09/xmldsig#")]
public partial class SignatureSignedInfoCanonicalizationMethod
{

    private string algorithmField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Algorithm
    {
        get
        {
            return this.algorithmField;
        }
        set
        {
            this.algorithmField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.w3.org/2000/09/xmldsig#")]
public partial class SignatureSignedInfoSignatureMethod
{

    private string algorithmField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Algorithm
    {
        get
        {
            return this.algorithmField;
        }
        set
        {
            this.algorithmField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.w3.org/2000/09/xmldsig#")]
public partial class SignatureSignedInfoReference
{

    private SignatureSignedInfoReferenceTransforms transformsField;

    private SignatureSignedInfoReferenceDigestMethod digestMethodField;

    private string digestValueField;

    private string typeField;

    private string uRIField;

    /// <remarks/>
    public SignatureSignedInfoReferenceTransforms Transforms
    {
        get
        {
            return this.transformsField;
        }
        set
        {
            this.transformsField = value;
        }
    }

    /// <remarks/>
    public SignatureSignedInfoReferenceDigestMethod DigestMethod
    {
        get
        {
            return this.digestMethodField;
        }
        set
        {
            this.digestMethodField = value;
        }
    }

    /// <remarks/>
    public string DigestValue
    {
        get
        {
            return this.digestValueField;
        }
        set
        {
            this.digestValueField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Type
    {
        get
        {
            return this.typeField;
        }
        set
        {
            this.typeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string URI
    {
        get
        {
            return this.uRIField;
        }
        set
        {
            this.uRIField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.w3.org/2000/09/xmldsig#")]
public partial class SignatureSignedInfoReferenceTransforms
{

    private SignatureSignedInfoReferenceTransformsTransform transformField;

    /// <remarks/>
    public SignatureSignedInfoReferenceTransformsTransform Transform
    {
        get
        {
            return this.transformField;
        }
        set
        {
            this.transformField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.w3.org/2000/09/xmldsig#")]
public partial class SignatureSignedInfoReferenceTransformsTransform
{

    private string algorithmField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Algorithm
    {
        get
        {
            return this.algorithmField;
        }
        set
        {
            this.algorithmField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.w3.org/2000/09/xmldsig#")]
public partial class SignatureSignedInfoReferenceDigestMethod
{

    private string algorithmField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Algorithm
    {
        get
        {
            return this.algorithmField;
        }
        set
        {
            this.algorithmField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.w3.org/2000/09/xmldsig#")]
public partial class SignatureKeyInfo
{

    private string[] x509DataField;

    private string idField;

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("X509Certificate", IsNullable = false)]
    public string[] X509Data
    {
        get
        {
            return this.x509DataField;
        }
        set
        {
            this.x509DataField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Id
    {
        get
        {
            return this.idField;
        }
        set
        {
            this.idField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.w3.org/2000/09/xmldsig#")]
public partial class SignatureObject
{

    private bankIdSignedData bankIdSignedDataField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.bankid.com/signature/v1.0.0/types")]
    public bankIdSignedData bankIdSignedData
    {
        get
        {
            return this.bankIdSignedDataField;
        }
        set
        {
            this.bankIdSignedDataField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.bankid.com/signature/v1.0.0/types")]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.bankid.com/signature/v1.0.0/types", IsNullable = false)]
public partial class bankIdSignedData
{

    private bankIdSignedDataUsrVisibleData usrVisibleDataField;

    private string usrNonVisibleDataField;

    private bankIdSignedDataSrvInfo srvInfoField;

    private bankIdSignedDataClientInfo clientInfoField;

    private string idField;

    /// <remarks/>
    public bankIdSignedDataUsrVisibleData usrVisibleData
    {
        get
        {
            return this.usrVisibleDataField;
        }
        set
        {
            this.usrVisibleDataField = value;
        }
    }

    /// <remarks/>
    public string usrNonVisibleData
    {
        get
        {
            return this.usrNonVisibleDataField;
        }
        set
        {
            this.usrNonVisibleDataField = value;
        }
    }

    /// <remarks/>
    public bankIdSignedDataSrvInfo srvInfo
    {
        get
        {
            return this.srvInfoField;
        }
        set
        {
            this.srvInfoField = value;
        }
    }

    /// <remarks/>
    public bankIdSignedDataClientInfo clientInfo
    {
        get
        {
            return this.clientInfoField;
        }
        set
        {
            this.clientInfoField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Id
    {
        get
        {
            return this.idField;
        }
        set
        {
            this.idField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.bankid.com/signature/v1.0.0/types")]
public partial class bankIdSignedDataUsrVisibleData
{

    private string charsetField;

    private string visibleField;

    private string valueField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string charset
    {
        get
        {
            return this.charsetField;
        }
        set
        {
            this.charsetField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string visible
    {
        get
        {
            return this.visibleField;
        }
        set
        {
            this.visibleField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public string Value
    {
        get
        {
            return this.valueField;
        }
        set
        {
            this.valueField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.bankid.com/signature/v1.0.0/types")]
public partial class bankIdSignedDataSrvInfo
{

    private string nameField;

    private string nonceField;

    private string displayNameField;

    /// <remarks/>
    public string name
    {
        get
        {
            return this.nameField;
        }
        set
        {
            this.nameField = value;
        }
    }

    /// <remarks/>
    public string nonce
    {
        get
        {
            return this.nonceField;
        }
        set
        {
            this.nonceField = value;
        }
    }

    /// <remarks/>
    public string displayName
    {
        get
        {
            return this.displayNameField;
        }
        set
        {
            this.displayNameField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.bankid.com/signature/v1.0.0/types")]
public partial class bankIdSignedDataClientInfo
{

    private string funcIdField;

    private string versionField;

    private bankIdSignedDataClientInfoEnv envField;

    /// <remarks/>
    public string funcId
    {
        get
        {
            return this.funcIdField;
        }
        set
        {
            this.funcIdField = value;
        }
    }

    /// <remarks/>
    public string version
    {
        get
        {
            return this.versionField;
        }
        set
        {
            this.versionField = value;
        }
    }

    /// <remarks/>
    public bankIdSignedDataClientInfoEnv env
    {
        get
        {
            return this.envField;
        }
        set
        {
            this.envField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.bankid.com/signature/v1.0.0/types")]
public partial class bankIdSignedDataClientInfoEnv
{

    private bankIdSignedDataClientInfoEnvAI aiField;

    /// <remarks/>
    public bankIdSignedDataClientInfoEnvAI ai
    {
        get
        {
            return this.aiField;
        }
        set
        {
            this.aiField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.bankid.com/signature/v1.0.0/types")]
public partial class bankIdSignedDataClientInfoEnvAI
{

    private string typeField;

    private string deviceInfoField;

    private string uhiField;

    private byte fsibField;

    private string utbField;

    private bankIdSignedDataClientInfoEnvAIRequirement requirementField;

    private string uauthField;

    /// <remarks/>
    public string type
    {
        get
        {
            return this.typeField;
        }
        set
        {
            this.typeField = value;
        }
    }

    /// <remarks/>
    public string deviceInfo
    {
        get
        {
            return this.deviceInfoField;
        }
        set
        {
            this.deviceInfoField = value;
        }
    }

    /// <remarks/>
    public string uhi
    {
        get
        {
            return this.uhiField;
        }
        set
        {
            this.uhiField = value;
        }
    }

    /// <remarks/>
    public byte fsib
    {
        get
        {
            return this.fsibField;
        }
        set
        {
            this.fsibField = value;
        }
    }

    /// <remarks/>
    public string utb
    {
        get
        {
            return this.utbField;
        }
        set
        {
            this.utbField = value;
        }
    }

    /// <remarks/>
    public bankIdSignedDataClientInfoEnvAIRequirement requirement
    {
        get
        {
            return this.requirementField;
        }
        set
        {
            this.requirementField = value;
        }
    }

    /// <remarks/>
    public string uauth
    {
        get
        {
            return this.uauthField;
        }
        set
        {
            this.uauthField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.bankid.com/signature/v1.0.0/types")]
public partial class bankIdSignedDataClientInfoEnvAIRequirement
{

    private bankIdSignedDataClientInfoEnvAIRequirementCondition conditionField;

    /// <remarks/>
    public bankIdSignedDataClientInfoEnvAIRequirementCondition condition
    {
        get
        {
            return this.conditionField;
        }
        set
        {
            this.conditionField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.bankid.com/signature/v1.0.0/types")]
public partial class bankIdSignedDataClientInfoEnvAIRequirementCondition
{

    private string typeField;

    private string valueField;

    /// <remarks/>
    public string type
    {
        get
        {
            return this.typeField;
        }
        set
        {
            this.typeField = value;
        }
    }

    /// <remarks/>
    public string value
    {
        get
        {
            return this.valueField;
        }
        set
        {
            this.valueField = value;
        }
    }
}

