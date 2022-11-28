import { useContext, useEffect } from "react";
import ICharacterContext from "../../interfaces/characters/ICharacterContext";
import {CharacterContext} from "../../contexts/CharacterContext";
import CharacterList from "./CharacterList";

const GetAllCharacters = () => {

    const { getAllCharactersFromService } = useContext(CharacterContext) as ICharacterContext;

    useEffect(() => {
        getAllCharactersFromService();
    }, [getAllCharactersFromService]);

    return (
        <CharacterList />
    )
}

export default GetAllCharacters