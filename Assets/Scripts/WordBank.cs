using UnityEngine;
using System.Collections;

public class WordBank : MonoBehaviour {
	public Hashtable bank = new Hashtable();
	public bool blocking = true;
	public int timer = 180;

	// Use this for initialization
	void Start () {
	this.bank.Add("Mouth", "The process of digestion starts here as food is broken into smaller pieces and carbohydrates are digested");
	this.bank.Add("Teeth", "Found in the mouth, these crush food into smaller, easier to digest pieces");
	this.bank.Add("Amylase", "An enzyme that digests carbohydrates, turning starch into sugars");
	this.bank.Add("Ptyalin", "A special type of amylase found in saliva");
	this.bank.Add("Esophagus", "Food travels down this tube passing from the mouth to the stomach");
	this.bank.Add("Stomach", "This organ secretes protein-digesting enzymes and strong acids");
	this.bank.Add("Gastrin", "This peptide hormone detects food in the stomach and stimulates the secretion of gastric acids");
	this.bank.Add("Hydrochloric acid", "A strong acid that converts pepsinogen to pepsin (also called HCl)");
	this.bank.Add("Pepsin", "An enzyme that digests proteins");
	this.bank.Add("Renin", "An enzyme specifically meant for digesting milk protein");
	this.bank.Add("Gelatinase", "An enzyme that breaks down gelatin and collagen of meat");
	this.bank.Add("Lipase", "An enzyme that breaks down butter fat to fatty acids and glycerol");
	this.bank.Add("Mucus", "This coats the stomach lining to protect it from acids");
	this.bank.Add("Small Intestine", "A narrow winding tube where digestion is completed and nutrients are absorbed into the blood");
	this.bank.Add("Duodenum", "The first and shortest segment of the small intestine");
	this.bank.Add("Steapsin", "A special form of Lipase made in the pancreas");
	this.bank.Add("Villi", "Tiny finger-like projection along the inner lining of the Small Intestine that absorb nutrients");
	this.bank.Add("Pancreas", "A large gland behind the stomach that secretes digestive enzymes into the duodenum");
	this.bank.Add("Liver","This organ secretes bile along with handling toxins in the body");
	this.bank.Add("Gallbladder","Bile from the liver is stored here before being secreted into the small intestine");
	this.bank.Add("Large Intestine","A tube at the end of the digestive tract where water is absorbed");
	this.bank.Add("Colon","Another name for the Large Intestine");
	}
	
	public string RandomWord(){
		ArrayList keys = new ArrayList(this.bank.Keys);
		return keys[UnityEngine.Random.Range(0,keys.Count)].ToString();
	}
	
	// Update is called once per frame
	void Update () {
	}
}