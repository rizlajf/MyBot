using Microsoft.Bot.Connector;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace MarkiBot
{
    public class ProductContentClass
    {
        // Construct a base URL for Image
        // To allow it to be found wherever the application is deployed
        string strCurrentURL = ConfigurationManager.AppSettings["strCurrentURL"];
        HeroCard heroCard = null;
        List<HeroCard> heroCardList = new List<HeroCard>();

        public List<HeroCard> GenerateAmplifiersContent()
        {
            // Full URL to the image
            string lodriversurfacemounts = String.Format(@"{0}/{1}", strCurrentURL, "Images/amp_lo_driver_surface_mounts_adm-0026-5929sm_crop.png");
            // Create a CardImage and add our image
            List<CardImage> cardImages1 = new List<CardImage>();
            cardImages1.Add(new CardImage(url: lodriversurfacemounts));
            // Create a CardAction to make the HeroCard clickable
            // Note this does not work in some Skype clients
            //CardAction btnAiHelpWebsite = new CardAction()
            //{
            //    Type = "openUrl",
            //    Title = "AiHelpWebsite.com",
            //    Value = "http://AiHelpWebsite.com"
            //};
            // Finally create the Hero Card
            // adding the image and the CardAction
            heroCard = new HeroCard()
            {
                Title = "LO Driver Surface Mount",
                Text = "Surface mount LO driver amplifiers are designed to function as the final output stage of the LO signal chain. Marki LO amplifiers provide a high power, fast rise time signal for driving a mixer’s LO port. Surface mount LO driver amplifiers  simplify system design by providing sufficient LO power to achieve the desired mixer spurious suppression, IP3, and other critical non-linear specifications. All ADM series amplifiers are available in a standard QFN package with broadband die versions available upon request.",
                Images = cardImages1,
                Buttons = new List<CardAction> { new CardAction(ActionTypes.OpenUrl, "More Info", value: "http://dev.markimicrowave.com/amplifiers/amplifiers-products.aspx#lo-driver-surface-mounts") }
            };
            heroCardList.Add(heroCard);

            string lodrivermodules = String.Format(@"{0}/{1}", strCurrentURL, "Images/amp_lo_driver_module_adm1-0026pa.png");
            List<CardImage> cardImages2 = new List<CardImage>();
            cardImages2.Add(new CardImage(url: lodrivermodules));
            heroCard = new HeroCard()
            {
                Title = "LO Driver Modules",
                Text = "Connectorized LO driver amplifier modules are designed to function as the final output stage of the LO signal chain in a coax connectorized package built ready for installation. Marki LO amplifiers provide a high power, fast rise time signal for driving a mixer’s LO port while providing a good impedance match. Connectorized LO driver amplifiers provide power up through millimeter wave frequencies and are unconditionally stable. LO driver amplifiers provide sufficient LO power to achieve the desired mixer spurious suppression, IP3, and other critical non-linear specifications. All ADM series modules are built using wirebonded amplifier onto a PWB with the bare die versions being available upon request.",
                Images = cardImages2,
                Buttons = new List<CardAction> { new CardAction(ActionTypes.OpenUrl, "More Info", value: "http://dev.markimicrowave.com/amplifiers/amplifiers-products.aspx#lo-driver-modules") }
            };
            heroCardList.Add(heroCard);

            string legacy = String.Format(@"{0}/{1}", strCurrentURL, "Images/amplifiers-legacy-hero-image.png");
            List<CardImage> cardImages3 = new List<CardImage>();
            cardImages3.Add(new CardImage(url: legacy));
            heroCard = new HeroCard()
            {
                Title = "Legacy",
                Text = "Legacy amplifiers are not recommended for new designs due to better alternatives being available. See the LO Driver Module tab for recommended products and replacement amplifiers.",
                Images = cardImages3,
                Buttons = new List<CardAction> { new CardAction(ActionTypes.OpenUrl, "More Info", value: "http://dev.markimicrowave.com/amplifiers/amplifiers-products.aspx#lo-driver-surface-mounts") }
            };
            heroCardList.Add(heroCard);

            return heroCardList;
        }

        public List<HeroCard> GenerateBalunContent()
        {
            string testandmeasurement = String.Format(@"{0}/{1}", strCurrentURL, "Images/Baluns/preview-full-Baluns-Test-Measurement-Hero-Image-BAL-0067-300x169.png");
            List<CardImage> testandmeasurementcardImages1 = new List<CardImage>();
            testandmeasurementcardImages1.Add(new CardImage(url: testandmeasurement));
            heroCard = new HeroCard()
            {
                Title = "Test & Measurement",
                Text = "Test and measurement baluns are connectorized modules that can be used in laboratory settings or built into temporary or permanent test sets. They are hand tuned to offer superior amplitude balance, phase balance, and common mode rejection ratio up to 67 GHz. Important specifications to consider when selecting a test and measurement balun include frequency coverage, excess insertion loss, and isolation between balanced ports. Data applications require a balun with frequency coverage to low frequencies, typically below 1 MHz. For converting a differential signal to a single ended signal it is best to use a balun with isolation, which is functionally equivalent to a 180˚ hybrid. For more information on how these specifications can affect system performance, consult our balun primer and tech notes.",
                Images = testandmeasurementcardImages1,
                Buttons = new List<CardAction> { new CardAction(ActionTypes.OpenUrl, "More Info", value: "http://dev.markimicrowave.com/baluns/baluns-products.aspx#test-and-measurement") }
            };
            heroCardList.Add(heroCard);

            string surfacemounts = String.Format(@"{0}/{1}", strCurrentURL, "Images/Baluns/preview-full-Baluns-Surface-Mounts-Hero-Image-BAL-0006SMG.png");
            List<CardImage> surfacemountsImages1 = new List<CardImage>();
            surfacemountsImages1.Add(new CardImage(url: surfacemounts));
            heroCard = new HeroCard()
            {
                Title = "Surface Mounts",
                Text = "Our surface mount baluns offer the best phase balance, amplitude balance, and common mode rejection over the widest bandwidths of any product commercially available. These surface mount baluns are commonly used to interface to analog to digital converters, digital to analog converters, and used in differential cable test sets.Unlike competing transformer baluns, our broadband baluns use a unique architecture combined with sophisticated and proprietary assembly techniques to provide the highest performance balun on the market.For applications above 1 GHz Marki also offers lower cost, capacitively - coupled baluns.",
                Images = surfacemountsImages1,
                Buttons = new List<CardAction> { new CardAction(ActionTypes.OpenUrl, "More Info", value: "http://dev.markimicrowave.com/baluns/baluns-products.aspx#surface-mounts") }
            };
            heroCardList.Add(heroCard);

            string inverters = String.Format(@"{0}/{1}", strCurrentURL, "Images/Baluns/preview-full-Baluns-Inverters-Hero-Image-INV-0040.png");
            List<CardImage> inverterscardImages1 = new List<CardImage>();
            inverterscardImages1.Add(new CardImage(url: inverters));
            heroCard = new HeroCard()
            {
                Title = "Inverters",
                Text = "Pulse inverters are available as connectorized modules up to 65 GHz operation. These laboratory devices use both magnetic and capacitive coupling to create an inverted or negative version of a voltage signal. In the frequency domain it introduces a broadband 180˚ phase shift to the input signal, while maintaining a flat group delay to ensure signal integrity.",
                Images = inverterscardImages1,
                Buttons = new List<CardAction> { new CardAction(ActionTypes.OpenUrl, "More Info", value: "http://dev.markimicrowave.com/baluns/baluns-products.aspx#inverters") }
            };
            heroCardList.Add(heroCard);

            return heroCardList;
        }

        public List<HeroCard> GenerateBiasTeesContent()
        {
            string testandmeasurement = String.Format(@"{0}/{1}", strCurrentURL, "Images/Bias_Tees/preview-full-Bias-Tees-Surface-Mounts-Hero-Image-BT-0034SMG-300x207.png");
            List<CardImage> testandmeasurementcardImages1 = new List<CardImage>();
            testandmeasurementcardImages1.Add(new CardImage(url: testandmeasurement));
            heroCard = new HeroCard()
            {
                Title = "Surface Mounts",
                Text = "Marki surface mount bias tees are built on a thin softboard substrate to enable high frequency operation. Marki produces high Q, small form factor, wire wound coils specifically for use in our surface mount bias tees. By using these internally produced coils and precisely controlling the assembly we can offer a smaller, higher frequency, resonance free bias tee than what is possible using commercially available wire wound coils. Most models (the 14, 24, and 34 GHz units) offer the option of using an external coil to extend the low end to the kHz range. Bypass capacitors can be added near the DC input port by the user to filter noise on the DC line. The 30 GHz model includes a bypass capacitor on the DC line that prevents low frequency extension, but provides noise filtering from the DC line.",
                Images = testandmeasurementcardImages1,
                Buttons = new List<CardAction> { new CardAction(ActionTypes.OpenUrl, "More Info", value: "http://dev.markimicrowave.com/bias-tees/bias-tees-products.aspx#biastees-surface-mounts") }
            };
            heroCardList.Add(heroCard);

            string surfacemounts = String.Format(@"{0}/{1}", strCurrentURL, "Images/Bias_Tees/preview-full-Bias-Tees-High-Power-Hero-Image-BTN2-0050.png");
            List<CardImage> surfacemountsImages1 = new List<CardImage>();
            surfacemountsImages1.Add(new CardImage(url: surfacemounts));
            heroCard = new HeroCard()
            {
                Title = "Modules",
                Text = "As with surface mount bias tees, connectorized bias tee modules are built using Marki’s proprietary wirewound coil technology. Precision assembly allows for ultra-broadband resonance free operation in two different models. The BT models offer the lowest frequency coverage down to 4 kHz using large integrated inductors. The more compact BTN models offer the same high frequency coverage without the large integrated inductors. These models are all capable of 500 mA of DC current, up to 30V of DC bias voltage, and 1 watt of RF power.",
                Images = surfacemountsImages1,
                Buttons = new List<CardAction> { new CardAction(ActionTypes.OpenUrl, "More Info", value: "http://dev.markimicrowave.com/bias-tees/bias-tees-products.aspx#biastees-modules") }
            };
            heroCardList.Add(heroCard);

            string inverters = String.Format(@"{0}/{1}", strCurrentURL, "Images/Bias_Tees/modules-hero-image.png");
            List<CardImage> inverterscardImages1 = new List<CardImage>();
            inverterscardImages1.Add(new CardImage(url: inverters));
            heroCard = new HeroCard()
            {
                Title = "High Power",
                Text = "There are two major limitations on the DC power handling of a bias tee: the voltage rating of the DC blocking capacitor and the current handling capability of the wirewound coil. Marki high power bias tees use high voltage blocking capacitors, which are more prone to resonance due to parasitic inductance. In addition to DC voltage, these capacitors allow high RF power of 10 watts for lower frequency and 5 watts for higher frequency bias tees. These bias tees also use proprietary wirewound coils with thick wire allowing for higher current capability.",
                Images = inverterscardImages1,
                Buttons = new List<CardAction> { new CardAction(ActionTypes.OpenUrl, "More Info", value: "http://dev.markimicrowave.com/bias-tees/bias-tees-products.aspx#bias-tees-high-power") }
            };
            heroCardList.Add(heroCard);

            return heroCardList;
        }

        public List<HeroCard> GenerateCouplersContent()
        {
            string highDirectivityBridge = String.Format(@"{0}/{1}", strCurrentURL, "Images/Couplers/preview-upload_card-Couplers-High-Directivity-Bridge-Hero-Image-CBR16-0012.png");
            List<CardImage> highDirectivityBridge1 = new List<CardImage>();
            highDirectivityBridge1.Add(new CardImage(url: highDirectivityBridge));
            heroCard = new HeroCard()
            {
                Title = "High Directivity Bridge",
                Text = "These couplers offer the highest possible directivity across a very broad bandwidth, including to low frequencies (down to kHz). Unlike stripline couplers that are based on quarter wave capacitively coupled structures, bridge couplers are based on Marki’s industry leading magnetically coupled baluns. They are the best choice for return loss measurements due to their high directivity. Their higher insertion loss and lower power handling make them a poor choice for amplifier and load-pull testing.",
                Images = highDirectivityBridge1,
                Buttons = new List<CardAction> { new CardAction(ActionTypes.OpenUrl, "More Info", value: "http://dev.markimicrowave.com/couplers/couplers-products.aspx#high-directivity-bridge") }
            };
            heroCardList.Add(heroCard);

            string StriplineDirectional = String.Format(@"{0}/{1}", strCurrentURL, "Images/Couplers/preview-upload_card-Couplers-Stripline-Directional-Hero-Image-C13-0150.png");
            List<CardImage> StriplineDirectional1 = new List<CardImage>();
            StriplineDirectional1.Add(new CardImage(url: StriplineDirectional));
            heroCard = new HeroCard()
            {
                Title = "Stripline Directional",
                Text = "Marki uses proprietary design techniques and software to create the highest performance directional couplers in the world. These couplers are based on industry standard triplate stripline construction techniques, making them suitable for high reliability applications. Each coupler is bidirectional, meaning that it can be used in both the forward and reverse direction when the coupled ports are terminated with 50Ω circuits, either loads or detectors. Some models come with one port terminated in a 50Ω load, while most have both coupled ports available. They have been tested to 50 watts of input power (see this tech note) and are suitable for load-pull testing, output power monitoring, and other broadband applications. Custom designs are possible for high volume requirements.",
                Images = StriplineDirectional1,
                Buttons = new List<CardAction> { new CardAction(ActionTypes.OpenUrl, "More Info", value: "http://dev.markimicrowave.com/couplers/couplers-products.aspx#stripline-directional") }
            };
            heroCardList.Add(heroCard);

            string LowLossHighPower = String.Format(@"{0}/{1}", strCurrentURL, "Images/Couplers/preview-upload_card-Couplers-Low-Loss-High-Power-Hero-Image-C17-0R518.png");
            List<CardImage> LowLossHighPower1 = new List<CardImage>();
            LowLossHighPower1.Add(new CardImage(url: LowLossHighPower));
            heroCard = new HeroCard()
            {
                Title = "Low Loss High Power",
                Text = "Low insertion loss couplers are perfect for load-pull and other test applications that are sensitive to loss or use high powers. Marki uses two types of construction for low loss couplers. High power stripline couplers use wider traces and thicker circuit boards than our standard stripline directional couplers, but their multisection design provides low loss but with a flat coupling value across the band. Airline directional couplers, as the name implies, use air as the dielectric material. This provides the lowest possible loss and correspondingly highest power handling, but with a coupling factor that varies across the band. These couplers are ideal for low loss or high power applications where the coupling factor can be calibrated out. Power handling of both types of couplers is limited by the connectors, which are available in N, APC-7, SMA, 2.92, and 2.4mm for different models of coupler..",
                Images = LowLossHighPower1,
                Buttons = new List<CardAction> { new CardAction(ActionTypes.OpenUrl, "More Info", value: "http://dev.markimicrowave.com/couplers/couplers-products.aspx#low-loss-high-power") }
            };
            heroCardList.Add(heroCard);

            string DualDirectional = String.Format(@"{0}/{1}", strCurrentURL, "Images/Couplers/preview-upload_card-Couplers-Dual-Directional-Hero-Image-CD10-0114.png");
            List<CardImage> DualDirectional1 = new List<CardImage>();
            DualDirectional1.Add(new CardImage(url: DualDirectional));
            heroCard = new HeroCard()
            {
                Title = "Dual Directional",
                Text = "While our stripline directional couplers are bidirectional and can measure power in both directions with 50Ω detectors, there are some applications that use non-50Ω power detectors. For these applications a dual directional coupler allows the user to measure power in both the forward and reverse directions without degradation in directivity due to impedance mismatch presented by the power detector. A dual directional coupler is two bidirectional couplers fabricated back to back, making each coupler insensitive to the non-50Ω coupled port termination.",
                Images = DualDirectional1,
                Buttons = new List<CardAction> { new CardAction(ActionTypes.OpenUrl, "More Info", value: "http://dev.markimicrowave.com/couplers/couplers-products.aspx#dual-directional") }
            };
            heroCardList.Add(heroCard);

            string PickOffTees = String.Format(@"{0}/{1}", strCurrentURL, "Images/Couplers/pick-off-tees-hero-image.png");
            List<CardImage> PickOffTees1 = new List<CardImage>();
            PickOffTees1.Add(new CardImage(url: PickOffTees));
            heroCard = new HeroCard()
            {
                Title = "Pick-Off Tees",
                Text = "A pick off tee is a resistive circuit that provides non-directional coupling of microwave signals. Due to reflections, a directional coupler is preferred for most applications. In an extremely well matched system a Marki pick off tee can provide extremely broadband signal monitoring in a very small package.",
                Images = PickOffTees1,
                Buttons = new List<CardAction> { new CardAction(ActionTypes.OpenUrl, "More Info", value: "http://dev.markimicrowave.com/couplers/couplers-products.aspx#pick-off-tees") }
            };
            heroCardList.Add(heroCard);
            return heroCardList;
        }

        public List<HeroCard> GenerateEqualizersContent()
        {
            string SurfaceMounts = String.Format(@"{0}/{1}", strCurrentURL, "Images/Equalizers/x.png");
            List<CardImage> SurfaceMounts1 = new List<CardImage>();
            SurfaceMounts1.Add(new CardImage(url: SurfaceMounts));
            heroCard = new HeroCard()
            {
                Title = "Surface Mounts",
                Text = "COMING SOON – Marki surface mount equalizers package our chip equalizers into a QFN package. They are suitable for general purpose equalization of circuit traces, amplifiers, and other components up to 30 GHz.",
                Images = SurfaceMounts1,
                Buttons = new List<CardAction> { new CardAction(ActionTypes.OpenUrl, "More Info", value: "http://dev.markimicrowave.com/equalizers/equalizers-products.aspx#equalizers-surface-mounts") }
            };
            heroCardList.Add(heroCard);

            string BareDieModules1 = String.Format(@"{0}/{1}", strCurrentURL, "Images/Equalizers/bare-die_modules-hero-image.png");
            string BareDieModules2 = String.Format(@"{0}/{1}", strCurrentURL, "Images/Equalizers/bare-die_modules-hero-image-meq3-30ach.png");
            List<CardImage> BareDieModules= new List<CardImage>();
            BareDieModules.Add(new CardImage(url: BareDieModules1));
            BareDieModules.Add(new CardImage(url: BareDieModules2));
            heroCard = new HeroCard()
            {
                Title = "Bare Die/Modules",
                Subtitle = "",
                Images = BareDieModules,
                Text = "Marki equalizer modules provide broadband equalization with return loss, low minimum insertion loss, and flat group delay. In addition, the MEQ products are available as a small form factor wire bondable chip, economically priced for high volume applications.",
                Buttons = new List<CardAction> { new CardAction(ActionTypes.OpenUrl, "More Info", value: "http://dev.markimicrowave.com/equalizers/equalizers-products.aspx#equalizers-chips-modules") }
            };
            heroCardList.Add(heroCard);            
            return heroCardList;
        }
    }
}