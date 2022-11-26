import axios from "axios";
import IGame from "../interfaces/games/IGame";

const GameService = (
    () => {
        const gameEndPoint = "https://localhost:7132/api/game";
        const imageUploadEndPoint = "https://localhost:7132/api/UploadImage";

        const getImagePathFromServer = async () => {
            const response = await axios.get(`${imageUploadEndPoint}/games`);
            return response.data;
        }

        const uploadImageToServer = async (image: File) => {
            const formData = new FormData();
            formData.append("file", image);
            //const response = await axios.post(imageUploadEndPoint, formData);
            const response = await axios({
                url: imageUploadEndPoint,
                method: "POST",
                data: formData,
                headers: {"Content-Type": "multipart/form-data"}
            });

            formData.delete("file");
            return response.data;
        }

        const getAllGamesFromServer = async () => {
            const response = await axios.get(gameEndPoint);
            return response.data;
        }

        const getGameByIdFromServer = async (id: number) => {
            const result = await axios.get(`${gameEndPoint}/${id}`);
            return result.data;
        }

        const getGameByTitleFromServer = async (title: string) => {
            const result = await axios.get(`${gameEndPoint}/Title/${title}`); //mulig endepunktet må være med titlecase
            return result.data;
        }

        const getGamesByGenreFromServer = async (genre: number) => {
            const result = await axios.get(`${gameEndPoint}/Genre/${genre}`);
            return result.data;
        }

        const getGamesByPlatformFromServer = async (platform: string) => {
            const result = await axios.get(`${gameEndPoint}/platform/${platform}`);
            return result.data;
        }

        const getGamesByDeveloperFromServer = async (developer: string) => {
            const result = await axios.get(`${gameEndPoint}/developer/${developer}`);
            return result.data;
        }

        const putGameToServer = async (game: IGame) => {
            const result = await axios.put(`${gameEndPoint}/${game.id}`, game);
            return result.data;
        }

        return {
            getImagePathFromServer,
            uploadImageToServer,
            getAllGamesFromServer,
            getGameByIdFromServer,
            getGameByTitleFromServer,
            getGamesByGenreFromServer,
            getGamesByPlatformFromServer,
            getGamesByDeveloperFromServer,
            putGameToServer
        }
    }
)();

export default GameService;