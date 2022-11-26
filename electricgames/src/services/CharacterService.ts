import axios from "axios";

const CharacterService = (
    () => {
        const apiEndpoint = "https://localhost:7132/api";
        const characterEndPoint = `${apiEndpoint}/character`;

        const getAllCharactersFromServer = async () => {
            const result = await axios.get(characterEndPoint);
            return result.data;
        }

        const getCharacterByIdFromServer = async (id: number) => {
            const result = await axios.get(`${characterEndPoint}/${id}`);
            return result.data;
        }

        const getCharacterByNameFromServer = async (name: string) => {
            const result = await axios.get(`${characterEndPoint}/name/${name}`);
            return result.data;
        }

        const getCharactersByGameFromServer = async (game: string) => {
            const result = await axios.get(`${characterEndPoint}/game/${game}`);
            return result.data;
        }

        return {
            getAllCharactersFromServer,
            getCharacterByIdFromServer,
            getCharacterByNameFromServer,
            getCharactersByGameFromServer
        }
    }
)();

export default CharacterService;