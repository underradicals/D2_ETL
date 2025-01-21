/** @import {DamageTypeProps} from '../../../types.js' */


/**
 *
 * @param {DamageTypeProps} props
 * @description Small panel for displaying the DamageType Data.
 * @returns {JSX.Element}
 * @constructor
 */
function DamageTypeCard({damageType}) {
    const {id, name, color: {red, green, blue, alpha}, description, icon} = damageType;
    return (
        <div key={id} className='dt-info-block'>
            <p className={`dt-info-block--header`}>
                <span className={`dt-info--title`}>{name}</span>
                <span className='dt-info--square'
                      style={{backgroundColor: `rgba(${red}, ${(green)}, ${(blue)}, ${(alpha)})`}}></span>
            </p>
            <p className={`dt-info-block--desc`}>{description}</p>
            <img className={`dt-icon-image`} src={`${(icon)}`} alt=""/>
        </div>
    )
}

export default DamageTypeCard;