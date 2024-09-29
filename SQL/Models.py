from typing import List, Optional
from sqlmodel import SQLModel, Field, Relationship
from datetime import datetime

class Competition_Driver_Link(SQLModel, table = True):
    '''This class is used to connect competitions to drivers and a many-to-many relationship'''
    competition_id: int | None = Field(default = None, foreign_key ="competition.id", primary_key = True)
    driver_id: int | None = Field(default= None, foreign_key = "driver.id", primary_key = True)
    is_attending: bool = False

    competition: "Competition" = Relationship(back_populates = "driver_links")
    driver: "Driver" = Relationship(back_populates = "competition_links")

class Driver_Truck_Link(SQLModel, table = True):
    '''This class is used to connect drivers to trucks and a many-to-many relationship'''
    driver_id: int | None = Field(default = None, foreign_key ="driver.id", primary_key = True)
    truck_id: int | None = Field(default= None, foreign_key = "truck.id", primary_key = True)
    is_attending: bool = False

    driver: "Driver" = Relationship(back_populates = "truck_links")
    truck: "Truck" = Relationship(back_populates = "driver_links")

class Competitions(SQLModel, table = True):
    '''This class creates a table in the database for competitions'''
    __tablename__ = "competitions"
    id: Optional[int] = Field(default = None, primary_key = True)
    date: Optional[datetime] = Field(default = None, primary_key = True)
    location: str
    name: str
    admins: str
    driver_links: list["Competition_Driver_Link"] = Relationship(back_populates = "competitions")
    
class Competition(SQLModel):
    '''This class is used to create a competition'''
    id: Optional[int] = Field(default = None, primary_key = True)
    date: Optional[datetime] = Field(default = None, primary_key = True)
    location: str
    name: str
    admins: str
    drivers: str 

class Drivers(SQLModel, table = True):
    '''This class is used to create a table of drivers'''
    __tablename__ = "drivers"
    id: Optional[int] = Field(default = None, primary_key = True)
    name: str
    score: Optional[int] = Field(default = None, primary_key = True)
    competition_links: list[Competition_Driver_Link] = Relationship(back_populates = "drivers")
    truck_links: list["Driver_Truck_Link"] = Relationship(back_populates = "drivers")

class Driver(SQLModel):
    '''This class is used to create a driver'''
    id: Optional[int] = Field(default = None, primary_key = True)
    name: str
    truck: str
    score: Optional[int] = Field(default = None, primary_key = True)

class Trucks(SQLModel, table = True):
    '''This class is used to create a table of trucks'''
    id: Optional[int] = Field(default = None, primary_key = True)
    name: str
    driver_links: list["Driver_Truck_Link"] = Relationship(back_populates = "trucks")

class Truck(SQLModel):
    '''This class is used to create a truck'''
    id: Optional[int] = Field(default = None, primary_key = True)
    name: str
