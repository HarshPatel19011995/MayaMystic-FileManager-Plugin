<!-- HEADER -->

<div align="center">

<img src="https://raw.githubusercontent.com/HarshPatel19011995/FileManager-Plugin/main/Documentation~/logo.png" width="90"/>

<h1>📁 MayaMystic FileManager</h1>

<p>
<b>Modular and scalable file management framework for Unity</b>
</p>

</div>

<br>

<!-- BANNER -->

<p align="center">
<img src="https://raw.githubusercontent.com/HarshPatel19011995/FileManager-Plugin/main/.github/banner.png" width="900"/>
</p>

<hr>

<h2>📑 Table of Contents</h2>

<ul>
<li><b><a href="#overview">📌 Overview</a></b></li>
<li><b><a href="#quick-start">⚡ Quick Start</a></b></li>
<li><b><a href="#key-features">✨ Key Features</a></b></li>
<li><b><a href="#architecture">🧠 Architecture</a></b></li>
<li><b><a href="#file-lifecycle">🔄 File Operation Lifecycle</a></b></li>
<li><b><a href="#core-components">⚙ Core Components</a></b></li>
<li><b><a href="#package-information">📦 Package Information</a></b></li>
<li><b><a href="#package-structure">📁 Package Structure</a></b></li>
<li><b><a href="#documentation">📚 Documentation</a></b></li>
<li><b><a href="#samples">🧪 Samples</a></b></li>
<li><b><a href="#roadmap">🗺 Roadmap</a></b></li>
<li><b><a href="#changelog">📜 Changelog</a></b></li>
<li><b><a href="#license">📄 License</a></b></li>
<li><b><a href="#author">👤 Author</a></b></li>
</ul>

<hr>

<h2 id="overview">📌 Overview</h2>

<p>
<b>MayaMystic FileManager</b> is a modular and reusable runtime file management framework for Unity.
</p>

<p>
It provides scalable utilities for handling file operations including text, JSON, binary data, hashing, directory management, and runtime storage workflows.
</p>

<h3>Built-in solutions include</h3>

<ul>
<li>Text file operations</li>
<li>JSON serialization</li>
<li>Binary file handling</li>
<li>Runtime directory creation</li>
<li>Path generation utilities</li>
<li>File hashing</li>
<li>Nested folder support</li>
</ul>

<hr>

<h2 id="quick-start">⚡ Quick Start</h2>

<details>

<summary><b>Click to expand installation steps</b></summary>

<br>

<h3>1️⃣ Install via Git</h3>

Open <b>Unity Package Manager</b>

<pre>
Window → Package Manager
</pre>

Click

<pre>
+ → Add package from Git URL
</pre>

Paste

<pre>
https://github.com/HarshPatel19011995/FileManager-Plugin.git
</pre>

<hr>

<h3>2️⃣ Generate File Path</h3>

<pre>
string filePath =
    PathUtility.GenerateFilePath(
        FilePathType.PersistentData,
        "SaveData",
        "PlayerData",
        "json");
</pre>

<hr>

<h3>3️⃣ Save JSON</h3>

<pre>
FileManagerService.Instance.SaveJson(
    filePath,
    playerData);
</pre>

<hr>

<h3>4️⃣ Load JSON</h3>

<pre>
PlayerData loadedData =
    FileManagerService.Instance
        .LoadJson&lt;PlayerData&gt;(filePath);
</pre>

</details>

<hr>

<h2 id="key-features">✨ Key Features</h2>

<table>
<tr>
<th>Feature</th>
<th>Description</th>
</tr>

<tr>
<td><b>Centralized FileManagerService</b></td>
<td>Unified runtime file operations</td>
</tr>

<tr>
<td><b>JSON Serialization</b></td>
<td>Save/load structured runtime data</td>
</tr>

<tr>
<td><b>Binary File Support</b></td>
<td>Read/write binary file content</td>
</tr>

<tr>
<td><b>Runtime Directory Utilities</b></td>
<td>Automatic folder creation and management</td>
</tr>

<tr>
<td><b>Nested Path Support</b></td>
<td>Supports scalable folder structures</td>
</tr>

<tr>
<td><b>Hash Utilities</b></td>
<td>MD5 and SHA256 hashing support</td>
</tr>

<tr>
<td><b>Configurable Architecture</b></td>
<td>ScriptableObject-driven settings system</td>
</tr>
</table>

<hr>

<h2 id="architecture">🧠 Architecture</h2>

<details>
<summary><b>View Architecture Diagram</b></summary>

<br>

<pre>
                ┌─────────────────────┐
                │  FileManagerService │
                └──────────┬──────────┘
                           │
        ┌──────────────────┼──────────────────┐
        ▼                  ▼                  ▼
┌────────────────┐ ┌────────────────┐ ┌────────────────┐
│ PathUtility    │ │ DirectoryUtil  │ │ FileHashUtil   │
└──────┬─────────┘ └──────┬─────────┘ └──────┬─────────┘
       │                  │                  │
       └──────────────────┼──────────────────┘
                          │
                          ▼
                ┌─────────────────────┐
                │ FileReadWriteUtility│
                └──────────┬──────────┘
                           │
                           ▼
                ┌─────────────────────┐
                │ Runtime File System │
                └─────────────────────┘
</pre>

<h3>Benefits</h3>

<ul>
<li>Clean modular architecture</li>
<li>Reusable runtime file workflows</li>
<li>Scalable folder organization</li>
<li>Production-ready runtime storage foundation</li>
</ul>

</details>

<hr>

<h2 id="file-lifecycle">🔄 File Operation Lifecycle</h2>

<details>

<summary><b>View File Lifecycle</b></summary>

<br>

<pre>
Client Code
    ↓
PathUtility
    ↓
Directory Validation
    ↓
FileManagerService
    ↓
Read/Write Utility
    ↓
Runtime Storage
    ↓
Result Returned
</pre>

</details>

<hr>

<h2 id="core-components">⚙ Core Components</h2>

<h3>🔹 FileManagerService</h3>

Responsible for centralized runtime file operations.

<ul>
<li>Text save/load</li>
<li>JSON serialization</li>
<li>Binary data handling</li>
<li>File deletion</li>
<li>Hash generation</li>
</ul>

<pre>
FileManagerService.Instance.SaveJson(...);
</pre>

<hr>

<h3>🔹 PathUtility</h3>

Provides safe and scalable path generation.

<pre>
PathUtility.GenerateFilePath(...)
</pre>

Features:

<ul>
<li>Nested folder support</li>
<li>PersistentData support</li>
<li>StreamingAssets support</li>
<li>TemporaryCache support</li>
<li>Filename sanitization</li>
</ul>

<hr>

<h3>🔹 FileHashUtility</h3>

Supported hashing algorithms

<pre>
MD5
SHA256
</pre>

<hr>

<h2 id="package-information">📦 Package Information</h2>

<table>
<tr><th>Property</th><th>Value</th></tr>
<tr><td>Package Name</td><td><code>com.mayamystic.filemanager</code></td></tr>
<tr><td>Version</td><td><b>1.0.0</b></td></tr>
<tr><td>Minimum Unity Version</td><td>2021.3 LTS</td></tr>
<tr><td>License</td><td>Proprietary – MayaMystic</td></tr>
</table>

<hr>

<h2 id="package-structure">📁 Package Structure</h2>

<pre>
Runtime/
 ├── Core/
 ├── Config/
 ├── Models/
 ├── Utilities/
 └── Constants/

Samples~/
Documentation~/
</pre>

<hr>

<h2 id="documentation">📚 Documentation</h2>

Full documentation:

<pre>
Documentation~/
</pre>

Includes:

<ul>
<li>Getting Started</li>
<li>Architecture Overview</li>
<li>Path System</li>
<li>Hash Utilities</li>
<li>Runtime Storage Workflow</li>
</ul>

<hr>

<h2 id="samples">🧪 Samples</h2>

<pre>
Samples~/Basic Usage
</pre>

Demonstrates

<ul>
<li>Saving/loading text files</li>
<li>JSON serialization</li>
<li>Binary file handling</li>
<li>Hash generation</li>
<li>File deletion</li>
</ul>

<hr>

<h2 id="roadmap">🗺 Roadmap</h2>

<table>
<tr><th>Version</th><th>Planned Features</th></tr>
<tr><td>v1.1</td><td>Runtime encryption utilities</td></tr>
<tr><td>v1.1</td><td>Compression support</td></tr>
<tr><td>v1.2</td><td>Async file operations</td></tr>
<tr><td>v1.2</td><td>Download cache integration</td></tr>
<tr><td>v1.3</td><td>File versioning system</td></tr>
<tr><td>v2.0</td><td>Cross-platform secure storage layer</td></tr>
</table>

<hr>

<h2 id="changelog">📜 Changelog</h2>

<pre>
CHANGELOG.md
</pre>

<hr>

<h2 id="license">📄 License</h2>

<pre>
LICENSE.md
</pre>

Proprietary – MayaMystic  
All rights reserved.

<hr>

<h2 id="author">👤 Author</h2>

<b>Harsh Patel</b>  
MayaMystic

GitHub  
https://github.com/HarshPatel19011995

<hr>

<h2>⭐ Contributing</h2>

Currently maintained internally.  
External contributions may be accepted in future releases.