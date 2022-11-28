import { useContext } from "react";
import ICharacterContext from "../../interfaces/characters/ICharacterContext";
import { CharacterContext } from "../../contexts/CharacterContext";
import CharacterItem from "./CharacterItem";

const CharacterList = () => {
    const { characters } = useContext(CharacterContext) as ICharacterContext;

    const getCharacterItems = () => {
        return characters.map((character, index) => (
            <CharacterItem
                key={`character-${index}`}
                id={character.id}
                name={character.name}
                description={character.description}
                image={character.image}
            />
        ));
    };


    return (<section className="new-list-container">{getCharacterItems()}</section>);

}

export default CharacterList;