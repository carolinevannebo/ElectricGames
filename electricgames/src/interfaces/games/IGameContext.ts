import IGame from "./IGame";

interface IGameContext {
    games: IGame[];
    getAllGamesFromService: () => void;
    getGameByIdFromService: (id: number) => void;
    getGameByTitleFromService: (title: string) => void;
    getGamesByGenreFromService: (genre: string) => void;
    getGamesByPlatformFromService: (platform: string) => void;
    getGamesByDeveloperFromService: (developer: string) => void;
    putGameToService: (game: IGame) => void;
}

export default IGameContext;