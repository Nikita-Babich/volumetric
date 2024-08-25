# volumetric
 3d c# game

# Idea:
1. Create a 3d game where all volumes are described with vectors ( not with surface triangles)
2. Use core of C# without fancy libraries or Visual Studio

## How it works
Local up axis of the observer is always alligned with global w, that creates the feeling of standing straight and gravity.
Tilts are not allowed, so xw yw zw rotations are banned.
Observer can move along all axis, but can rotate only "horisontally": xy, xz, yz

Collision points and colors are found as solutions for ray and body's mathematical equation intersection.

