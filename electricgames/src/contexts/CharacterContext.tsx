import { useEffect, useState, createContext, ReactNode } from "react";
import ICharacterContext from "../interfaces/characters/ICharacterContext";
import ICharacter from "../interfaces/characters/ICharacter";
import CharacterService from "../services/CharacterService";

export const CharacterContext = createContext<ICharacterContext | null>(null);

type Props = { children: ReactNode };

const CharacterProvider = ({ children }: Props) => {

    const [characters, setCharacter] = useState<ICharacter[]>([]);

    useEffect(() => {
        getAllCharactersFromService();
    }, []);

    const getAllCharactersFromService = async () => {
        const response = await CharacterService.getAllCharactersFromServer();
        setCharacter(response);
    }

    const getCharacterByIdFromService = async (id: number) => {
        const response = await CharacterService.getCharacterByIdFromServer(id);
        const array = [];
        array.push(response);
        setCharacter(array);
    }

    const getCharacterByNameFromService = async (name: string) => {
        const response = await CharacterService.getCharacterByNameFromServer(name);
        const array = [];
        array.push(response);
        setCharacter(array);
    }

    const getCharactersByGameFromService = async (game: string) => {
        const response = await CharacterService.getCharactersByGameFromServer(game);
        const array = [];
        array.push(response);
        setCharacter(array);
    }

    return (
        <CharacterContext.Provider value={{ 
            characters,
            getAllCharactersFromService,
            getCharacterByIdFromService,
            getCharacterByNameFromService,
            getCharactersByGameFromService
        }}>
        {children}
        </CharacterContext.Provider>
    )
}

export default CharacterProvider;