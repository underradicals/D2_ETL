import './style.css';

interface IDamageType {
  id: number;
  name: string;
  description: string;
  subtitle: string;
}

type AppState = {
  ammoTypeData: IDamageType | {};
  isLoaded: boolean;
  isError: boolean;
  errors: any[]
}

const state: AppState = {
  ammoTypeData: {},
  isLoaded: false,
  isError: false,
  errors: []
}

async function get(url: string) {
  const result = await fetch(url).catch((err: any) => {
    state.isError = true;
    state.errors.push(err);
  });
  if (!result?.ok) console.log("Error has occurred: " + result?.status);
  return await result?.json();
}

async function setData(data: IDamageType) {
  console.log(data);
  state.ammoTypeData = data;
}

function ObserveBody(list: MutationRecord[], observer: MutationObserver) {
  for (const mutation of list) {
    const type: MutationRecordType = mutation.type;

    if (type === "childList") {
      console.log("Set to true if mutations to target’s children are to be observed.");
      console.log(mutation, observer);
    }

    if (type === "attributes") {
      console.log("Set to true if mutations to target’s attributes are to be observed. Can be omitted if attributeOldValue or attributeFilter is specified.");
      console.log(mutation);
    }

    if (type === "subtree") {
      console.log("Set to true if mutations to not just target, but also target’s descendants are to be observed.")
      console.log(mutation);
    }

    if (type === "characterData") {
      console.log("Set to true if mutations to target’s data are to be observed. Can be omitted if characterDataOldValue is specified.");
      console.log(mutation);
    }

    if (type === "attributeOldValue") {
      console.log("Set to true if attributes is true or omitted and target’s attribute value before the mutation needs to be recorded.")
      console.log(mutation);
    }

    if (type === "characterDataOldValue") {
      console.log("Set to true if characterData is set to true or omitted and target’s data before the mutation needs to be recorded.");
      console.log(mutation);
    }

    if (type === "attributeFilter") {
      console.log("Set to a list of attribute local names (without namespace) if not all attribute mutations need to be observed and attributes is true or omitted.");
      console.log(mutation);
    }
  }
}

async function DOMContentLoaded() {
  const response = await get("http://localhost:5164/damage_type");
  await setData(response);
  state.isLoaded = true;
}

async function Run(id: number) {
  clearInterval(id);
  console.log(state.ammoTypeData);
  const config = { attributes: true, childList: true, subtree: true, characterData: true };
  const observer = new MutationObserver(ObserveBody);
  observer.observe(document.body, config);

  addEventListener("blur", () => {
    console.log("blur");
    observer.disconnect();
    const div = document.querySelector("div");
    document.body.removeChild(div as Element);
  });

  addEventListener("focus", () => {
    console.log("focus");
    observer.observe(document.body, config);
    document.body.insertAdjacentHTML("afterbegin", "<div>Hello World</div>");
    const el = document.querySelector("div") as Element;
    el?.setAttribute("data-id", "true");
    el.textContent = "";
    el.textContent = "Hello Texas";
  });

  document.body.insertAdjacentHTML("afterbegin", "<div>Hello World</div>");
  const el = document.querySelector("div") as Element;
  el?.setAttribute("data-id", "true");
  el.textContent = "";
  el.textContent = "Hello Texas";
}

async function Loaded() {
  const id = setInterval(async () => {
    if (state.isLoaded) {
      await Run(id);
    } else {
      console.log("Not loaded yet");
    }
  }, 100)
}

addEventListener("DOMContentLoaded", DOMContentLoaded);

addEventListener("load", Loaded);