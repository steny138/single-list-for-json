// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);

namespace single_list_json_demo;

public class TxcResponse
{
    public Orders orders { get; set; }
}

public class BannerImage
{
    public List<Media> medias { get; set; }
}

public class Channel
{
    public string IndirectOrderChannel { get; set; }
}

public class Client
{
    public string EndClientIdentityCode { get; set; }
}

public class ClientQuotationProductSoldPrice
{
    public object SoldPrice { get; set; }
    public object SoldPriceWithTax { get; set; }
}

public class ContractSKU
{
    public object Balance { get; set; }
    public double FaceValueWithTax { get; set; }
    public double FaceValue { get; set; }
}

public class ExpirationPolicy
{
    public string ExpiryScheme { get; set; }
}

public class FootNote
{
    public List<Tag> tags { get; set; }
}

public class Item
{
    public string OrderNumber { get; set; }
    public List<Client> client { get; set; }
    public List<Channel> channel { get; set; }
    public List<OrderProductInfo> OrderProductInfos { get; set; }
    public List<Quotation> quotation { get; set; }
}

public class Media
{
    public string ImageURL { get; set; }
}

public class OrderProductInfo
{
    public List<ExpirationPolicy> expirationPolicy { get; set; }
    public ProductVersion productVersion { get; set; }
}

public class Orders
{
    public SingleList<Item> items { get; set; }
}

public class Product
{
    public string ProductCode { get; set; }
    public bool ProductStatus { get; set; }
    public int ProductType { get; set; }
    public bool IsMasterProduct { get; set; }
    public List<Program> program { get; set; }
    public object productExternalProperties { get; set; }
}

public class ProductCodeSoldPriceMappingList
{
    public string ProductCode { get; set; }
    public List<ClientQuotationProductSoldPrice> clientQuotationProductSoldPrice { get; set; }
}

public class ProductTemplate
{
    public List<ProductTemplateSet> productTemplateSet { get; set; }
}

public class ProductTemplateSet
{
    public List<ProductTemplateVersion> productTemplateVersions { get; set; }
}

public class ProductTemplateTagValue
{
    public List<BannerImage> BannerImage { get; set; }
    public List<FootNote> FootNotes { get; set; }
}

public class ProductTemplateVersion
{
    public List<ProductTemplateTagValue> productTemplateTagValues { get; set; }
}

public class ProductVersion
{
    public object ExpiryDate { get; set; }
    public string ProductName { get; set; }
    public string ProductDescription { get; set; }
    public int TagName { get; set; }
    public List<ContractSKU> contractSKU { get; set; }
    public List<ProductTemplate> productTemplates { get; set; }
    public Product product { get; set; }
}

public class Program
{
    public string ProgramCode { get; set; }
}

public class Quotation
{
    public List<object> applyConditionBusinessType { get; set; }
    public List<ProductCodeSoldPriceMappingList> ProductCodeSoldPriceMappingList { get; set; }
}


public class Tag
{
    public List<object> tagValue { get; set; }
}

