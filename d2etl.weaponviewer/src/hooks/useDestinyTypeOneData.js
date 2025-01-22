/** @import {DamageTypeDefinition} from '../../types.js' */
import {useEffect, useState} from "react";

/** @type {DamageTypeDefinition} */
const initialState = {
    name: '',
    description: '',
    icon: '',
    color: {
        red: 255,
        green: 255,
        blue: 255,
        alpha: 255,
    }
}

function useDestinyTypeOneData(damage_type) {
    const [allTypes, setAllTypes] = useState([]);
    const [typesById, setTypesById] = useState(initialState);

    function loadDamageTypeData() {
        fetch(`http://localhost:5164/${damage_type}`)
            .then(res => res.json())
            .then(data => {
                console.log(data);
                setAllTypes(data);
                setTypesById(data[0]);
            });
    }

    useEffect(loadDamageTypeData, []);
    return [allTypes, typesById, setTypesById];
}

export default useDestinyTypeOneData;