import GameCenterForm from "./GameCenterForm";

export const EditGameCenter = () => {
    return(
        <>
            <h3>Edit Game Center</h3>
            <GameCenterForm model={
                {
                    name: "Småland", 
                    latitude: 57.78066842497087, 
                    longitude: 14.16906738333637
                }} 
            onSubmit={values => console.log(values)}/>
        </>
    )
}