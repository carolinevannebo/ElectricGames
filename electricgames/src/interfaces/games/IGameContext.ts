import IGame from "./IGame";

interface IGameContext {
    games: IGame[];
    getImagePathFromService: () => Promise<string>;
    //uploadImageToService: (image: File) => Promise<string>;
    uploadImageToService: (image: File) => Promise<string>;
    getAllGamesFromService: () => void;
    getGameByIdFromService: (id: number) => void;
    getGameByTitleFromService: (title: string) => void;
    getGamesByGenreFromService: (genre: number) => void;
    getGamesByPlatformFromService: (platform: string) => void;
    getGamesByDeveloperFromService: (developer: string) => void;
    postGameToService: (game: IGame) => void;
    putGameToService: (game: IGame, id: number) => void;
    deleteGameFromService: (id: number) => void;
}

export default IGameContext;