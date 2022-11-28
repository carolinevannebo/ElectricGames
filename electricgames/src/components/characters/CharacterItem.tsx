import ICharacter from "../../interfaces/characters/ICharacter";
import '../../styles/shared/Item.css';

const CharacterItem = ({
    id, name, description, image }: ICharacter) => {

    return (
        <article>
            <div className="div-img">
                <img src={`https://localhost:7132/images/characters/${image}`} alt={`${name}`} />
            </div>
            <div className="div-content">
                <h3>{name} <span>({id})</span></h3>
                <div>
                    <p>Description: <span className="color-seperator">{description}</span></p>
                </div>
            </div>
        </article>
    )
}

export default CharacterItem;