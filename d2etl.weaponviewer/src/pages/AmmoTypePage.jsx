import NavigationButtonGroup from "../components/NavigationButtonGroup/NavigationButtonGroup.jsx";
import RouteHeader from "../components/RouteHeader/RouteHeader.jsx";
import useDestinyTypeOneData from "../hooks/useDestinyTypeOneData.js";
import DamageTypeCard from "../features/DamageTypeCard/DamageTypeCard.jsx";

function AmmoTypePage(props) {
    const [allTypes, typesById, setTypesById] = useDestinyTypeOneData('ammo_type');
    
    function renderColorIcon(id) {
        if (id === 1) {
            return <span className='dt-info--square' style={{backgroundColor: `rgba(255, 255, 255, 1)`}}></span>
        }else if (id === 2) {
            return <span className='dt-info--square' style={{backgroundColor: `rgba(53, 227, 102, 255)`}}></span>
        } else {
            return <span className='dt-info--square' style={{backgroundColor: `rgba(77, 136, 255, 255)`}}></span>
        }
    }

    function handleOnClick(id) {
        return function (e) {
            fetch("http://localhost:5164/ammo_type/" + id)
                .then(res => res.json())
                .then(data => {
                    setTypesById(data);
                });
        }
    }

    function createAmmoTypeByIdButtonGroup(item) {
        return item.name !== 'Raid' ? (
            <button key={item.id} className={`nav-button`} data-target={item.id}
                    onClick={handleOnClick(item.id)}>{item.name}</button>
        ) : ('')
    }

    function mapAmmoTypeByIdButtonList(allTypes) {
        return allTypes.map(createAmmoTypeByIdButtonGroup);
    }

    return (
        <>
            <NavigationButtonGroup/>
            <RouteHeader method={`get`} route={`ammo_type`}/>
            <div className={`dt-icon-container`}>
                {allTypes.map(item => (<div key={item.id} className='dt-info-block'>
                    <p className={`dt-info-block--header`}>
                        <span className={`dt-info--title`}>{item.name}</span>
                        {renderColorIcon(item.id)}
                    </p>
                    <p className={`dt-info-block--desc`}>{item.description}</p>
                    <img className={`dt-icon-image`} src={`${(item.icon)}`} alt=""/>
                </div>))}
            </div>
            <RouteHeader method={`get`} route={`ammo_type/id`}/>
            <div className={`dt-icon-container`}>
                {mapAmmoTypeByIdButtonList(allTypes)}
            </div>
            <div className={`dt-icon-container`}>
                <div className='dt-info-block'>
                    <p className={`dt-info-block--header`}>
                        <span className={`dt-info--title`}>{typesById.name}</span>
                        
                    </p>
                    <p className={`dt-info-block--desc`}>{typesById.description}</p>
                    <img className={`dt-icon-image`} src={`${(typesById.icon)}`} alt=""/>
                </div>
            </div>
        </>
    )
}


export default AmmoTypePage;