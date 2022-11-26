import IGame from "./IGame";

interface IGameContext {
    games: IGame[];
    getImagePathFromService: () => Promise<string>;
    getAllGamesFromService: () => void;
    getGameByIdFromService: (id: number) => void;
    getGameByTitleFromService: (title: string) => void;
    getGamesByGenreFromService: (genre: number) => void;
    getGamesByPlatformFromService: (platform: string) => void;
    getGamesByDeveloperFromService: (developer: string) => void;
    putGameToService: (game: IGame) => void;
}

export default IGameContext;