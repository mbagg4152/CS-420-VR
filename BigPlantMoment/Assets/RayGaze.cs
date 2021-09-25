using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class RayGaze : MonoBehaviour {
    Ray ray;
    RaycastHit hitData;
    Camera mainCam;
    Canvas txtCanvas;
    TextMeshProUGUI label;
    Image qmark;
    Image infoPanel;
    Text infoText;
    Text nameText;

    void Start(){
       mainCam = Camera.main;
       label = GameObject.Find("LabelText").GetComponent<TextMeshProUGUI>();
       label.text = "+";
       qmark = GameObject.Find("qmark").GetComponent<Image>();
       qmark.enabled = false;
       infoPanel = GameObject.Find("infoPanel").GetComponent<Image>();
       infoPanel.enabled=false;
       infoText = GameObject.Find("infoText").GetComponent<Text>();
       infoText.text = "";
       nameText = GameObject.Find("nameText").GetComponent<Text>();
       nameText.text = "";
    }


    void Update(){
        ray = Camera.main.ViewportPointToRay(new Vector3 (0.5f, 0.5f, 0)); // center of the viewport
      
        if(Physics.Raycast(ray, out hitData)){
            string tag = hitData.collider.tag;
            if (tag.Equals("Untagged")){ // clear UI values
                label.text = "+"; // go back to crosshair
                infoText.text = ""; // hide text
                nameText.text = ""; // hide text
                qmark.enabled = false; 
                infoPanel.enabled = false;
            } else {
                float dist = Vector3.Distance(mainCam.transform.position, hitData.transform.position);
                if (dist < 12){
                    label.text = tag;
                    qmark.enabled = true;
                    if (Input.GetKey(KeyCode.JoystickButton15) || Input.GetKey(KeyCode.Mouse0)) {
                        infoPanel.enabled = true;
                        plantInfo(tag); // display the information about the plant
                    }
                }
            }
        } else { // clear UI values
            label.text = "+"; // go back to crosshair
            infoText.text = ""; // hide text
            nameText.text = ""; // hide text
            qmark.enabled = false; 
            infoPanel.enabled = false;
        }
        
    }


    void plantInfo(string tag){
        switch(tag){
            case "Fly Agaric":
                nameText.text = "Scientific name:\nAmanita muscaria\n\nCommon name(s):\nFly agaric, fly amanita";
                infoText.text = "This mushroom is one of the most iconic and recognizable toadstool species. It can be found in northern forests around the world. It is a poisonus mushroom, but some will prepare it for safe eating.";
                break;
            case "King Trumpet":
                nameText.text = "Scientific name:\nPleurotus eryngii\n\nCommon name(s):\nKing Trumpet";
                infoText.text = "This mushroom is part of the oyster mushroom genus and is native to mediterranean regions of europe as well as the middle east and north africa.";
                break;
            case "Boabab":
                nameText.text = "Scientific name:\nAsansonia grandidieri\n\nCommon name(s):\nGrandidier's baobab";
                infoText.text = "This is the largest baobab tree found in madagascar. Like its relatives, it is an endangered species under the threat of spreading agricultural endeavors.";
                break;
             case "Paper Birch":
                nameText.text = "Scientific name:\nBetula papyrifera\n\nCommon name(s):\nPaper Birch";
                infoText.text = "The paper birch is a relatively short-lived tree native to northern north america and gets its name from the thin, white bark that peels in layers. Its bark is an excellent fire starter but should not be stripped from live trees.";
                break;
             case "Dracaena":
                nameText.text = "Scientific name:\nDracaena reflexa var. angustifolia\n\nCommon name(s):\nDracaena marginata";
                infoText.text = "This is one of many plants in the dracaena genus. It is native to madigascar and is one of the many dracaena species which are grown as house plants.";
                break;
             case "Douglass Fir":
                nameText.text = "Scientific name:\nPsuedotsuga menziesii\n\nCommon name(s):\nDouglass fir";
                infoText.text = "This member of the pine family is native to western north america. Despite its name, it is not a true fir. Its genus name actually means 'false hemlock' (hence the pseudo).";
                break;
             case "Scots pine":
                nameText.text = "Scientific name:\nPinus sylvestris\n\nCommon name(s):\nScots Pine";
                infoText.text = "This pine is native to eurasia. It avoids competition by thriving in poorer soil conditions, otherwise it is out-competed by other trees in more favorable conditions." ;
                break;
             case "Coconut palm":
                nameText.text = "Scientific name:\nCocos nucifera\n\nCommon name(s):\nCoconut palm";
                infoText.text = "This is the only living member of the cocos genus. This tropical icon is part of the palm tree family so it prefers nice balmy weather.";
                break;
             case "Rainbow Tree":
                nameText.text = "Scientific name:\nEucalyptus deglupta\n\nCommon name(s):\nRainbow Tree";
                infoText.text = "This is one of the only eucalyptus trees not found in australia and is the only eucalyptus tree to be commonly found in a rainforest setting.";
                break;
             case "Sandplain wattle":
                nameText.text = "Scientific name:\nAcacia murrayana\n\nCommon name(s):\nSandplain wattle";
                infoText.text = "This tree can be found in arid parts of australia. It is part of the pea/legume family and their seeds have been commonly eaten by australian natives.";
                break;
             case "Common Sunflower":
                nameText.text = "Scientific name:\nHelianthus annuus\n\nCommon name(s):\nCommon Sunflower";
                infoText.text = "This very tall flower is also very useful as its seeds can be eaten, made into oil and used in food for birds and livestock.";
                break;
             case "Spearmint":
                nameText.text = "Scientific name:\nMentha spicata\n\nCommon name(s):\nSpearmint";
                infoText.text = "This species of mint is native to europe and parts of asia. It is a perennial herbacious plant, and like other types of mints it can spread fast when not kept in check.";
                break;
             case "Garlic Mustard":
                nameText.text = "Scientific name:\nAlliaria petiolata\n\nCommon name(s):\nGarlic Mustard";
                infoText.text = "This herbacious plant is part of the mustard/broccoli family (brassicaceae). It is biennial, so it will flower and die at the end of its second season. It is one of the oldest known spices to have been used in europe.";
                break;
             case "Ostrich Fern":
                nameText.text = "Scientific name:\nMatteuccia struthiopteris\n\nCommon name(s):\nOstrich fern, Fiddlehead fern";
                infoText.text = "This fern is the only member of its genus and commonly forms colonies in various temperate regions around the globe. As its leaves grow they gradually unfurl from a tight spiral and then extend out to cover the ground.";
                break;
             case "Coleus":
                nameText.text = "Scientific name:\nColeus scutellariodes\n\nCommon name(s):\nColeus";
                infoText.text = "This decorative plant is part of the mint family. Like many other ornamental plants, humans have decided to selectively breed numerous cultivars which results in unique combinations of vibrant colors on their leaves.";
                break;
             case "Arrowhead Plant":
                nameText.text = "Scientific name:\nSyngonium podophyllum\n\nCommon name(s):\nArrowhead Plant";
                infoText.text = "This plant is a tropical plant that also has found itself to be quite a popular houseplant. In its native habitats located in central and south america, it will grow on the trunks of jungle trees by hooking itself to the bark with its roots.";
                break;
             case "Foxtail":
                nameText.text = "Scientific name:\nAgave attenuata\n\nCommon name(s):\nFoxtail";
                infoText.text = "This is one of the many species of agave. It is a popular plant due its aesthetics. Fun fact: agaves are part of the asparagus family!";
                break;
             case "Prickly Pear":
                nameText.text = "Scientific name:\nOpuntia ficus-indica\n\nCommon name(s):\nPrickly pear cactus";
                infoText.text = "This is a fairly popular type of cactus that has large defensive spines and features large, bisexual flowers.";
                break;
             case "English Walnut":
                nameText.text = "Scientific name:\nJuglans regia\n\nCommon name(s):\nEnglish Walnut";
                infoText.text = "This walnut tree is widely cultivated across europe and is the origin of cultivated edible varieties.";
                break;
             case "Plantpot dapperling":
                nameText.text = "Scientific name:\nLeucocoprinus birnbaumii\n\nCommon name(s):\nPlantpot dapperling";
                infoText.text = "This mushroom grows natively in the tropics and subtropics but can be found in planters, pots and greenhouses.";
                break;
             case "Bugleweed":
                nameText.text = "Scientific name:\nAjuga reptans\n\nCommon name(s):\nBugleweed";
                infoText.text = "This plant is a perennial and commonly grown as an ornamental plant. It has numerous colorful varieties and is part of the mint family.";
                break;
             case "Rubber Plant":
                nameText.text = "Scientific name:\nFicus elastica\n\nCommon name(s):\nRubber Plant";
                infoText.text = "This plant is actually part of the fig genus and cannot be used for making rubber. Similar to its relative the figs you'll find at the store, they need the help of a fig wasp to become pollinated.";
                break;
            default:
                nameText.text = "name";
                infoText.text = "information";
                break;
        }
    }
}