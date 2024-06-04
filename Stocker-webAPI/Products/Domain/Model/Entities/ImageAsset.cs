using System.Net.Mime;
using Stocker_webAPI.Products.Domain.Model.ValueObjects;

namespace Stocker_webAPI.Products.Domain.Model.Entities;

public class ImageAsset : Asset
{
    public Uri? ImageUri { get; }

    public override bool Readable => false;
    
    public override bool Viewable => true;

    public override string GetContent()
    {
        return (ImageUri != null) ? ImageUri.AbsoluteUri : string.Empty;
    }

    public ImageAsset() : base(EAssetType.Image)
    {
        
    }

    public ImageAsset(string imageUrl) : base(EAssetType.Image)
    {
        ImageUri = new Uri(imageUrl);
    }
}