import ICharacter from "./ICharacter";

interface ICharacterContext {
    characters: ICharacter[];
    getAllCharactersFromService: () => void;
    getCharacterByIdFromService: (id: number) => void;
    getCharacterByNameFromService: (name: string) => void;
    getCharactersByGameFromService: (game: string) => void;
}

export default ICharacterContext;