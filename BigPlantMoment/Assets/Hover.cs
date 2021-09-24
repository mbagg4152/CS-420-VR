using System.Text.RegularExpressions;
using System.Reflection.Emit;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Hover : MonoBehaviour {
    // Color mouseColor = new Color(0.75f, 0.44f, 1f, 1f);
    Color mouseColor = new Color(0f, 1f, 1f, 0.5f);
    // Color mouseColor = Color.red;
    List <Color> originals = new List<Color>();
    List <Material> mats = new List<Material>();
    MeshRenderer rend;
    Transform[] tforms;
    Camera mainCam;
    Canvas txtCanvas;
    TextMeshProUGUI label;
    Image qmark;
    Image infoPanel;
    Text infoText;
    Text nameText;

    void Start() {
        // mainCam = Camera.main;
        mainCam = GameObject.Find("UICam").GetComponent<Camera>();
        
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
        
        if (GetComponent<MeshRenderer>()){
            rend = GetComponent<MeshRenderer>();
            mats = rend.materials.OfType<Material>().ToList();
        } else {
            tforms = this.GetComponentsInChildren<Transform>();
            foreach (Transform tran in tforms){
                if(tran.GetComponent<MeshRenderer>()){
                    MeshRenderer tmpRend = tran.GetComponent<MeshRenderer>();
                    List <Material> tmpMats = tmpRend.materials.OfType<Material>().ToList();
                    foreach(Material mat in tmpMats){
                        mats.Add(mat);
                    }
                }
            }
        
        }
         foreach(Material mat in mats){
               if(mat.color != null){
                   originals.Add(mat.color);
               }
        }
    }

    void OnMouseOver(){
        float dist = Vector3.Distance(mainCam.transform.position, this.transform.position);
        if (dist <= 12) {
            label.text = this.tag;
            qmark.enabled = true;
            if (Input.GetKey(KeyCode.JoystickButton15)) {
                Debug.Log("clicked on");
                infoPanel.enabled = true;
                plantInfo(this.tag);
            }
        }
            
    }

    void OnMouseExit(){
        label.text = "+";
        infoText.text = "";
        nameText.text = "";
        qmark.enabled = false;
        infoPanel.enabled = false;
        if (mats.Count > 0){
            int index = 0;
            foreach(Material mat in mats){
                if (mat.color != null){
                    mat.color = originals[index];
                }
                index++;
            }
        }
    }


    void plantInfo(String tag){
        switch(tag){
            case "Fly Agaric":
                nameText.text = "Amanita muscaria\nFly agaric, fly amanita";
                infoText.text = "This mushroom is one of the most iconic and recognizable toadstool species. It can be found in northern" +
                                " forests around the world. It is a poisonus mushroom, but some will prepare it for safe eating.";
                break;
            case "King Trumpet":
                nameText.text = "Pleurotus eryngii\nKing Trumpet";
                infoText.text = "This mushroom is part of the oyster mushroom genus and is native to mediterranean regions of europe " +
                                "as well as the middle east and north africa.";
                break;
            case "Boabab":
                nameText.text = "Asansonia grandidieri\nGrandidier's baobab";
                infoText.text = "This is the largest baobab tree found in madagascar. Like its relatives, it is an endangered species " +
                                "under the threat of spreading agricultural endeavors.";
                break;
             case "Paper Birch":
                nameText.text = "Betula papyrifera\nPaper Birch";
                infoText.text = "The paper birch is a relatively short-lived tree native to northern north america and gets its name " +
                                "from the thin, white bark that peels in layers. Its bark is an excellent fire starter but should not " +
                                "be stripped from live trees.";
                break;
             case "Dracaena":
                nameText.text = "Dracaena reflexa var. angustifolia\nDracaena marginata";
                infoText.text = "This is one of many plants in the dracaena genus. It is native to madigascar and is one of the many" +
                                " dracaena species which are grown as house plants.";
                break;
             case "Douglass Fir":
                nameText.text = "Psuedotsuga menziesii\nDouglass fir";
                infoText.text = "This member of the pine family is native to western north america. Despite its name, it is not a true fir. " + 
                                "Its genus name actually means 'false hemlock' (hence the pseudo).";
                break;
             case "Scots Pine":
                nameText.text = " Pinus sylvestris\nScots Pine";
                infoText.text = "This pine is native to eurasia. It avoids competition by thriving in poorer soil conditions, " + 
                                "otherwise it is out-competed by other trees in more favorable conditions." ;
                break;
             case "Coconut palm":
                nameText.text = "Cocos nucifera\nCoconut palm";
                infoText.text = "This is the only living member of the cocos genus. This tropical icon is part of the palm tree family " + 
                                "so it prefers nice balmy weather.";
                break;
             case "Rainbow Tree":
                nameText.text = "Eucalyptus deglupta\nRainbow Tree";
                infoText.text = "This is one of the only eucalyptus trees not found in australia and is the only eucalyptus tree to be commonly found in " +
                                "a rainforest setting.";
                break;
             case "Sandplain wattle":
                nameText.text = "Acacia murrayana\nSandplain wattle";
                infoText.text = "This tree can be found in arid parts of australia. It is part of the pea/legume family and their seeds have been " +
                                "commonly eaten by australian natives.";
                break;
             case "Common Sunflower":
                nameText.text = "Helianthus annuus\nCommon Sunflower";
                infoText.text = "This very tall flower is also very useful as its seeds can be eaten, made into oil and used in food for birds and livestock.";
                break;
             case "Spearmint":
                nameText.text = "Mentha spicata\nSpearmint";
                infoText.text = "This species of mint is native to europe and parts of asia. It is a perennial herbacious plant, and like other types of mints " +
                                "it can spread fast when not kept in check.";
                break;
             case "Garlic Mustard":
                nameText.text = "Alliaria petiolata\nGarlic Mustard";
                infoText.text = "This herbacious plant is part of the mustard/broccoli family (brassicaceae). It is biennial, so it will flower and die at the end " + 
                                "of its second season. It is one of the oldest known spices to have been used in europe.";
                break;
             case "Ostrich Fern":
                nameText.text = "Matteuccia struthiopteris\nOstrich fern, Fiddlehead fern";
                infoText.text = "This fern is the only member of its genus and commonly forms colonies in various temperate regions around the globe. As its leaves grow " +
                                "they gradually unfurl from a tight spiral and then extend out to cover the ground.";
                break;
             case "Coleus":
                nameText.text = "Coleus scutellariodes\nColeus";
                infoText.text = "This decorative plant is part of the mint family. Like many other ornamental plants, humans have decided to selectively breed numerous cultivars" +
                                " which results in unique combinations of vibrant colors on their leaves.";
                break;
             case "Arrowhead Plant":
                nameText.text = "Syngonium podophyllum\nArrowhead Plant";
                infoText.text = "This plant is a tropical plant that also has found itself to be quite a popular houseplant. In its native habitats located in central and south america, "+
                                "it will grow on the trunks of jungle trees by hooking itself to the bark with its roots.";
                break;
             case "Foxtail":
                nameText.text = "Agave attenuata\nFoxtail";
                infoText.text = "This is one of the many species of agave. It is a popular plant due its aesthetics. Fun fact: agaves are part of the asparagus family!";
                break;
             case "Prickly Pear":
                nameText.text = "Opuntia ficus-indica\nPrickly pear cactus";
                infoText.text = "This is a fairly popular type of cactus that has large defensive spines and features large, bisexual flowers.";
                break;
             case "Common Walnut Tree":
                nameText.text = "";
                infoText.text = "";
                break;
             case "Plantpot dapperling":
                nameText.text = "";
                infoText.text = "";
                break;
             case "Bugleweed":
                nameText.text = "";
                infoText.text = "";
                break;
             case "Rubber Plant":
                nameText.text = "Rubber Plant/nFicus elastica";
                infoText.text = "This plant is actually part of the fig genus and cannot be made for rubber. Similar to its relative the figs " + 
                                "you'll find at the store, they need the help of a fig wasp to become pollinated.";
                break;
            default:
                nameText.text = "name";
                infoText.text = "information";
                break;
        }
    }



}