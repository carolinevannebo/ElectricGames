import ICharacter from "./ICharacter";

interface ICharacterContext {
    characters: ICharacter[];
    getAllCharactersFromService: () => void;
    getCharacterByIdFromService: (id: number) => void;
    getCharacterByNameFromService: (name: string) => void;
    getCharacterByGameFromService: (game: string) => void;
}

export default ICharacterContext;